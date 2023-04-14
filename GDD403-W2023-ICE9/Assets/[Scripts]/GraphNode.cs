using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    public List<GraphNode> neighbours;
    public bool isColliding;
    public Collider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (isColliding) ? Color.green : Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector3(1.0f, 1.0f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                isColliding = true;
                break;
            case "Enemy":
                isColliding = true;
                break;
            case "Bullet":
                isColliding = true;
                break;
        }

        collider2D = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                isColliding = false;
                break;
            case "Enemy":
                isColliding = false;
                break;
            case "Bullet":
                isColliding = false;
                break;
        }

        collider2D = null;
    }


}
