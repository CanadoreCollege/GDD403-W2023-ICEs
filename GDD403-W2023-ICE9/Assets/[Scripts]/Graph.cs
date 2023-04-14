using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public List<GraphNode> nodes;
    public float radius;

    // Start is called before the first frame update
    void Awake()
    {
        BuildGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildGrid()
    {
        // Add all child nodes to the nodes list
        foreach (Transform child in transform)
        {
            nodes.Add(child.GetComponent<GraphNode>());
        }

        // created all connections
        for (var i = 0; i < nodes.Count; i++)
        {
            for (var j = 0; j < nodes.Count; j++)
            {
                // ignore the node itself
                if (i != j)
                {
                    if (!Physics2D.Raycast(nodes[i].transform.position, Vector3.Normalize(nodes[j].transform.position - nodes[i].transform.position), radius))
                    {
                        if (Vector3.Distance(nodes[i].transform.position, nodes[j].transform.position) < radius)
                        {
                            nodes[i].neighbours.Add(nodes[j]);
                        }
                    }
                }
            }
        }
    }
}
