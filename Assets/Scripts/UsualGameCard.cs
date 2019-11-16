using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class UsualGameCard : GameCard
{
    public UsualGameCard(string id) : base(id) { }
    public void Accept(GameController g)
    {
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p3").Value) };
        g.Anonymity += p[0];
        g.Money += p[1];
        g.Feelings += p[2];
    }

    public void Decline(GameController g)
    {
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p3").Value) };
        g.Anonymity += p[0];
        g.Money += p[1];
        g.Feelings += p[2];
    }
}
