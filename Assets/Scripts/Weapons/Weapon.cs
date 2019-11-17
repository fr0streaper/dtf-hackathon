using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float cooldownTime;
    public bool isCoolingDown;
    public int maxAmmo;
    public int ammo;
    public float reloadTime;
    public bool isReloading;
    public float bulletForce;
    public float dispersion;


    IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCoolingDown = false;
    }
    IEnumerator ReloadingCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        ammo = maxAmmo;
    }
    public void Shoot()
    {
        if (isCoolingDown == false && isReloading == false)
        {
            isCoolingDown = true;
            StartCoroutine(CooldownCoroutine());
            ammo--;
            GameObject new_bullet = Instantiate(bullet);
            new_bullet.transform.position = transform.position + transform.rotation * Vector3.right * 0.5f;
            Quaternion rot = transform.rotation;
            rot = Quaternion.AngleAxis(rot.eulerAngles.z + Random.Range(-dispersion, dispersion), Vector3.forward);
            new_bullet.transform.rotation = rot;
            Vector2 force = new_bullet.transform.right * bulletForce;
            new_bullet.GetComponent<Rigidbody2D>().AddForce(force);
        }
        else if (isReloading == false && ammo <= 0)
        {
            StartCoroutine(ReloadingCoroutine());
            isReloading = true;
        }
    }
}
