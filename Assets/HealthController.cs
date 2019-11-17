using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Sprite RIP;
    public int Health;
    void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            transform.GetComponent<SpriteRenderer>().sprite = RIP;
            if (!GetComponent<Rigidbody2D>())
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 100);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().mass = 10;
        }

    }
}
