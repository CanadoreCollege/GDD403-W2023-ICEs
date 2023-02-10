using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card : MonoBehaviour
{

    [Header("Card Properties")]
    public string rankName;
    public string suit;
    public int value;
    public bool isFaceUp;

    public bool startFacing;

    [Header("Selection Properties")]
    public SelectionOutline selectionOutline;

    void Start()
    {
        Initialize();
        selectionOutline = FindObjectOfType<SelectionOutline>();
    }

    private void Update()
    {
        //if (startFacing != isFaceUp)
        //{
        //    Flip();
        //}
    }

    public void Flip()
    {
        transform.position = new Vector3(transform.position.x, 7.5f, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 0, Convert.ToInt32(isFaceUp) * 180);
        isFaceUp = !isFaceUp;
    }

    string toString()
    {
        return rankName + " of " + suit;
    }

    private void Initialize()
    {
        var split = name.Split('_');

        suit = split[0];

        String[] numberWords = { "Zero", "Ace", "Deuce", "Three", "Four", "Five", "Six",
                                "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

        switch (split[1])
        {
            case "A":
                value = 1;
                break;
            case "J":
                value = 11;
                break;
            case "Q":
                value = 12;
                break;
            case "K":
                value = 13;
                break;
            default:
                rankName = split[1];
                Int32.TryParse(rankName, out value);
                break;
        }

        rankName = numberWords[value];

        isFaceUp = true;
        startFacing = isFaceUp;
    }

    void OnMouseEnter()
    {
        EnableSelectionOutline();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Flip();
        }
    }

    void OnMouseExit()
    {
        DisableSelectionOutline();
    }

    // External Code

    private void EnableSelectionOutline()
    {
        Ray ray = selectionOutline.cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selectionOutline.TargetRenderer = hit.transform.GetComponent<Renderer>();
            if (selectionOutline.lastTarget == null) selectionOutline.lastTarget = selectionOutline.TargetRenderer;
            if (selectionOutline.SelectionMode == SelMode.AndChildren)
            {
                if (selectionOutline.ChildrenRenderers != null)
                {
                    Array.Clear(selectionOutline.ChildrenRenderers, 0, selectionOutline.ChildrenRenderers.Length);
                }

                selectionOutline.ChildrenRenderers = hit.transform.GetComponentsInChildren<Renderer>();
            }


            if (selectionOutline.TargetRenderer != selectionOutline.lastTarget || !selectionOutline.Selected)
            {
                selectionOutline.SetTarget();
            }

            selectionOutline.lastTarget = selectionOutline.TargetRenderer;
        }
        else
        {
            selectionOutline.TargetRenderer = null;
            selectionOutline.lastTarget = null;
            if (selectionOutline.Selected)
            {
                selectionOutline.ClearTarget();
            }
        }
    }

    private void DisableSelectionOutline()
    {
        if (selectionOutline.Selected)
        {
            selectionOutline.ClearTarget();
        }
    }
}

