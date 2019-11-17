using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyTriggerHandler : MonoBehaviour
{
    public AudioClip audio;
    public float aggroScale = 1f;
    public float aggroAlpha = 0.25f;
    public Color aggroColor = new Color(0xaf, 0, 0);
    public Sprite aggroSprite;

    private void Start()
    {
        gameObject.transform.localScale *= aggroScale;
        aggroColor -= new Color(0, 0, 0, 1f - aggroAlpha);
        gameObject.GetComponent<SpriteRenderer>().color = aggroColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject enemy = transform.parent.gameObject;
            enemy.GetComponent<FlyingEnemyController2D>().isAggressive = true;
            enemy.GetComponent<SpriteRenderer>().sprite = aggroSprite;
            AudioSource.PlayClipAtPoint(audio, collision.gameObject.transform.position);   
        }
    }
}
