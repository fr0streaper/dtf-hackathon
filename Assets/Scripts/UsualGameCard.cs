﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class UsualGameCard : GameCard
{
    public UsualGameCard(string id, string filename) : base(id, filename)  { }
    public override void Accept(GameController g)
    {
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p3").Value) };
        g.Anonymity = System.Math.Max(System.Math.Min(g.Anonymity + p[0], 100), 0);
        g.Money = System.Math.Max(System.Math.Min(g.Money + p[1], 100), 0);
        g.Feelings = System.Math.Max(System.Math.Min(g.Feelings + p[2], 100), 0);
    }

    public override void Decline(GameController g)
    {
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p3").Value) };
        g.Anonymity = System.Math.Max(System.Math.Min(g.Anonymity + p[0], 100), 0);
        g.Money = System.Math.Max(System.Math.Min(g.Money + p[1], 100), 0);
        g.Feelings = System.Math.Max(System.Math.Min(g.Feelings + p[2], 100), 0);
    }
}
