using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weap;
    private Weapon weapon;
    private void Start()
    {
        weapon = Instantiate(weap).GetComponent<Weapon>();
    }
    private void Update()
    {
        weapon.transform.position = transform.position + Vector3.up * 0.5f;
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateTo(pos);
    }

    private void RotateTo(Vector3 pos)
    {
        pos.z = 0;
        Vector3 dir = (pos - transform.position).normalized;
        weapon.transform.rotation = Quaternion.FromToRotation(Vector3.right, dir);
    }
}
