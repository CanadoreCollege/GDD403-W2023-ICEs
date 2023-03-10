using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    public Vector3 direction;
    public float rotationRate;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        var rotationAngle = Input.GetAxisRaw("Horizontal") * rotationRate * Time.deltaTime * -1.0f;
        var movementRate = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.Rotate(Vector3.forward, rotationAngle);
        var radiansAngle = transform.localEulerAngles.z * Mathf.Deg2Rad;
        direction = new Vector3((float)Mathf.Cos(radiansAngle), (float)Mathf.Sin(radiansAngle), 0.0f);

        transform.position += direction * movementRate;
    }
}
