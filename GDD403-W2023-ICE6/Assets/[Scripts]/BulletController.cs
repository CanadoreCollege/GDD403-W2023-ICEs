using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private BulletManager bulletManager;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    public void Activate()
    {
        Invoke("DestroyYourSelf", 5.0f);
    }

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
            bulletManager.ReturnBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DestroyYourSelf();
    }


}
