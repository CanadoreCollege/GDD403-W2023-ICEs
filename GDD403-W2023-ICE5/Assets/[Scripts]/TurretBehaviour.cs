using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        TurnTurretToFaceMouse();
    }

    private void TurnTurretToFaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        target = Vector3.Normalize(Camera.main.ScreenToWorldPoint(mousePos) - transform.position);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(target.x, -target.y) * Mathf.Rad2Deg - 90.0f);
    }
}
