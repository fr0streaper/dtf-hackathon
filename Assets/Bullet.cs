using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    private void OnCollisionEnter2D(Collision2D col)
    {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.SendMessage("ApplyDamage", Damage);
            }
        Destroy(gameObject);
    }
}
