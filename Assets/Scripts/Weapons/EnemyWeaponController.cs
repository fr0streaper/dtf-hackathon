using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    public GameObject weap;
    private Weapon weapon;
    private bool iCanShoot = true;
    private void Start()
    {
        weapon = Instantiate(weap).GetComponent<Weapon>();
    }

    IEnumerator ShootingCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        iCanShoot = true;
    }
    private void RotateTo(Vector3 pos)
    {
        pos.z = 0;
        Vector3 dir = (pos - transform.position).normalized;
        weapon.transform.rotation = Quaternion.FromToRotation(Vector3.right, dir);
    }
    void Update()
    {
        weapon.transform.position = transform.position + Vector3.up * 0.25f;
        if(GetComponent<WalkingEnemyController2D>().isAggressive &&
            GetComponent<WalkingEnemyController2D>().player)
        {
            Vector3 target = GetComponent<WalkingEnemyController2D>().player.position;
            RotateTo(target);
            if(iCanShoot)
            {
                iCanShoot = false;
                StartCoroutine(ShootingCoroutine());
                weapon.Shoot();
            }
        }
        
    }

}
