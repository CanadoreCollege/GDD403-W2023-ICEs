using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    [Header("Sensing Suite")] 
    public LayerMask collisionLayerMask;
    public bool isTargetDetected;
    public bool hasLOS;

    [Header("Targeting Properties")]
    public Transform targetTransform;
    public Transform turretTransform;

    private float targetDirection;
    private Vector2 targetDirectionVector;
    private Collider2D colliderName;


    // Start is called before the first frame update
    void Start()
    {
        targetDirectionVector = Vector2.zero;
        targetDirection = 0;

        targetTransform = FindObjectOfType<TankBehaviour>().transform;

        isTargetDetected = false;
        hasLOS = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargetDetected)
        {
            var hit = Physics2D.Linecast(transform.position, targetTransform.position, collisionLayerMask);
            colliderName = hit.collider;

            targetDirectionVector = (targetTransform.position - transform.position);
            targetDirectionVector.Normalize(); // creates a unit vector (magnitude of 1)
            targetDirection = Mathf.Atan2(targetDirectionVector.x, -targetDirectionVector.y) * Mathf.Rad2Deg;

            hasLOS = (hit.collider.gameObject.CompareTag("Player"));
            if (hasLOS)
            {
                turretTransform.localEulerAngles = new Vector3(0.0f, 0.0f, targetDirection - transform.localEulerAngles.z - 90.0f);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTargetDetected = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = (hasLOS) ? Color.green : Color.red;

        if (isTargetDetected)
        {
            Gizmos.DrawLine(transform.position, targetTransform.position);
        }

        Gizmos.color = (isTargetDetected) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, 4.75f);
    }
}
