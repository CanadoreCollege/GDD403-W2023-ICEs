using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // public instance Members
    [Header("Card Properties")]
    public string rankName;
    public string suit;
    public int value;
    public bool isFaceUp;

    private bool startFacing;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        var suitRankStrings = name.Split("_");

        var numberWords = new[]
        {
            "Zero", "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"
        };

        suit = suitRankStrings[0];

        switch (suitRankStrings[1])
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
                suit = suitRankStrings[0];
                Int32.TryParse(suitRankStrings[1], out value); // convert to an int

                break;
        }

        rankName = numberWords[value];

        isFaceUp = true;
        startFacing = isFaceUp;
    }

    public void Flip()
    {
        transform.position = new Vector3(transform.position.x, 7.5f, transform.position.z);
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (isFaceUp) ? 0.0f : 180.0f); // ternary operator
    }

    void Update()
    {
        if (startFacing != isFaceUp)
        {
            Flip();
            startFacing = isFaceUp;
        }
    }

    public override string ToString()
    {
        return $"{rankName} of {suit}s";
    }
}
