﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public AudioClip audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SendMessage("PlayerDead");
            AudioSource.PlayClipAtPoint(audio, collision.gameObject.transform.position);
        }
    }
}