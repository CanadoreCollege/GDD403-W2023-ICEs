using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Properties")] 
    [Range(0.01f, 0.2f)]
    public float speedValue = 0.02f;
    public bool timerisActive;
    public bool isLooping;
    public bool isReverse;

    //[Header("Path Points")]
    //private List<PathNode>

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
