using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject RIP;
    public GameObject YouDiedText;
    public int Health;
    void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            if(tag == "Player")
            {
                PlayerDie();
            }
            Instantiate(RIP).transform.position = transform.position;
            Destroy(gameObject);
        }

    }
    void PlayerDie()
    {
        Transform text = Instantiate(YouDiedText).transform;
        text.parent = FindObjectOfType<Canvas>().transform;
        text.transform.localPosition = Vector3.zero;
        FindObjectOfType<ScenesController>().FadeOutTo(0);
    }
}
