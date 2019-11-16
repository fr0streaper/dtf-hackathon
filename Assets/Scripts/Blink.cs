using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Blink : MonoBehaviour
{
    Text text;
    string txt;
    float timer = 0.3f;
    bool flag = false;
    void Start()
    {
        text = GetComponent<Text>();
        txt = text.text;
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        { 
            timer = 0.3f;
            if (flag)
                text.text = txt + '_';
            else
                text.text = txt;
            flag = !flag;
        }

    }
}
