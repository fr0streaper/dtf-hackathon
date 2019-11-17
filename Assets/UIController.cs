using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject player;
    private Text health;
    private Text ammo;
    private void Start()
    {
        health = transform.GetChild(0).GetComponent<Text>();
        ammo = transform.GetChild(1).GetComponent<Text>();
    }
    void Update()
    {
        if(player)
        { 
         health.text = "Health - " + player.GetComponent<HealthController>().Health;
         ammo.text = "Ammo - " + player.GetComponent<WeaponController>().weapon.ammo.ToString() + "\\" + player.GetComponent<WeaponController>().weapon.maxAmmo.ToString();
        }
    }
}
