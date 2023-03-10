using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyYourSelf", 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void DestroyYourSelf()
    {
        if (gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyYourSelf();
    }


}
