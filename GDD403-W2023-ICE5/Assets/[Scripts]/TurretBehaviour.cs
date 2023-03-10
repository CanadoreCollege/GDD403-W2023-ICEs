using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform bulletSpawn;
    public Transform bulletParent;
    public GameObject bulletPrefab;

    private Vector3 target;

    void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }


    void Start()
    {
        bulletParent = GameObject.Find("[BULLETS]").transform;
    }

    void Update()
    {
        TurnTurretToFaceMouse();
        FireBullet();
    }

    private void TurnTurretToFaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        target = Vector3.Normalize(Camera.main.ScreenToWorldPoint(mousePos) - transform.position);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(target.x, -target.y) * Mathf.Rad2Deg - 90.0f);
    }

    private void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity, bulletParent);
            var attackAngle = (transform.localEulerAngles.z + (transform.parent.transform.localEulerAngles.z)) * Mathf.Deg2Rad;
            var bulletDirection = new Vector3((float)Mathf.Cos(attackAngle), (float)Mathf.Sin(attackAngle), 0.0f);
            bullet.GetComponent<BulletController>().direction = bulletDirection;
            bullet.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (transform.localEulerAngles.z + transform.parent.transform.localEulerAngles.z));
        }
    }
}
