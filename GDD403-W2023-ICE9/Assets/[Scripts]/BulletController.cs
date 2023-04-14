using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private BulletManager bulletManager;
    private GameObject smokePrefab;
    private Transform bulletParent;
    void Awake()
    {
        smokePrefab = Resources.Load<GameObject>("Prefabs/Smoke");
    }

    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        bulletParent = GameObject.Find("[BULLETS]").transform;
    }

    public void Activate()
    {
        var turretSound = GetComponent<AudioSource>();
        turretSound.pitch = Random.Range(0.5f, 3.0f);
        turretSound.Play();
        Invoke("DestroyYourSelf", 2.0f);
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
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponent<TankBehaviour>().health.TakeDamage(10);
                break;
            case "Enemy":
                other.gameObject.GetComponent<EnemyController>().health.TakeDamage(10);
                break;
        }

        var explosionPoint = other.ClosestPoint(transform.position);

        DestroyYourSelf();

        // Create Smoke at the "hit" location
        Instantiate(smokePrefab, explosionPoint, Quaternion.identity, bulletParent);
    }


}
