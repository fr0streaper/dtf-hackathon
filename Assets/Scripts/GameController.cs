using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public int Anonymity { get; set; }
    public int Money { get;  set; }
    public int Feelings { get; set; }

    public GameController()
    {
        Anonymity = 100;
        Money = 100;
        Feelings = 100;
    }
}
