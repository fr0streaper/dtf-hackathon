using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    private void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Vector3 dir = (pos - transform.position).normalized;
        
        weapon.transform.rotation = Quaternion.FromToRotation(Vector3.right, dir); 
    }
    void FixedUpdate()
    {
        weapon.transform.position = transform.position + Vector3.up * 0.5f;

        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
    }
}
