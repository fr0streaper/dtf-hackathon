using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public GameObject expl;
    public int Damage;
    public float Timer;
    void Start()
    {
        StartCoroutine(ExplosionCoroutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 3.0f);
        foreach (var col in cols)
        {
            if (col.tag == "Enemy")
            {
                col.SendMessage("ApplyDamage", Damage);
            }
        }
        Instantiate(expl).transform.position = transform.position + Vector3.up * 0.25f;
        Destroy(gameObject);
    }

    IEnumerator ExplosionCoroutine()
    {
        yield return new WaitForSeconds(Timer);
        Explode();
    }
}
