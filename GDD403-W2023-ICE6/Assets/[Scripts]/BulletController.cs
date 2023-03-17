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
        Invoke("DestroyYourSelf", 5.0f);
    }

    // TODO: need an public Activate method

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
            // TODO: move the bullet back to the Pool
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyYourSelf();
    }


}
