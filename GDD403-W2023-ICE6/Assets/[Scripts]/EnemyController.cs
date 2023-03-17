using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Properties")] 
    [Range(0.001f, 0.02f)]
    public float speedValue = 0.01f;
    public bool timerIsActive;
    public bool isLooping;
    public bool isReverse;

    [Header("Path Points")] 
    public List<PathNode> pathNodes;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private PathNode currentNode;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        timerIsActive = true;
        isLooping = true;
        isReverse = false;

        startPoint = transform.position;
        BuildPathNodes();
    }

    private void BuildPathNodes()
    {
        // create an empty List Container
        pathNodes = new List<PathNode>();

        // add all PathNodes to the PathNodes List
        foreach (Transform child in transform)
        {
            if (!child.gameObject.CompareTag("Turret"))
            {
                var pathNode = new PathNode(child.position, null, null);
                pathNodes.Add(pathNode);
            }
        }

        // set up all links
        for (var i = 0; i < pathNodes.Count; i++)
        {
            pathNodes[i].next = (i == pathNodes.Count - 1) ? pathNodes[0] : pathNodes[i + 1];
            pathNodes[i].prev = (i == 0) ? pathNodes[^1] : pathNodes[i - 1];
        }

        currentNode = pathNodes[0];

        endPoint = currentNode.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        if (timerIsActive)
        {
            // increment timer
            if (timer <= 1.0f)
            {
                timer += speedValue;
            }

            // resets timer
            if (timer >= 1.0f)
            {
                timer = 0.0f;

                Traverse((isReverse) ? 0 : ^1, (isReverse) ? currentNode.prev : currentNode.next);
            }
        }
    }

    /// <summary>
    ///  This method traverses from one pathNode to the next depending on the direction of the motion (forward or reverse)
    /// </summary>
    /// <param name="boundaryIndex"></param>
    /// <param name="nextNode"></param>
    private void Traverse(System.Index boundaryIndex, PathNode nextNode)
    {
        startPoint = currentNode.position;
        endPoint = nextNode.position;

        if (currentNode != pathNodes[boundaryIndex])
        {
            currentNode = nextNode;
        }
        else if ((currentNode == pathNodes[boundaryIndex]) && (isLooping))
        {
            currentNode = nextNode;
        }
        else
        {
            timerIsActive = false;
        }
    }


    private void Move()
    {
        transform.position = Vector2.Lerp(startPoint, endPoint, timer);
    }
}