using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyTriggerHandler : MonoBehaviour
{
    public AudioClip audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject enemy = transform.parent.gameObject;
            enemy.GetComponent<FlyingEnemyController2D>().isAggressive = true;
            AudioSource.PlayClipAtPoint(audio, collision.gameObject.transform.position);   
        }
    }
}
