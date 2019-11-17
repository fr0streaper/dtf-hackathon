using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class UsualGameCard : GameCard
{
    XmlDocument sDoc = new XmlDocument();
    public UsualGameCard(string id, string filename) : base(id, filename)  { }
    public override void Accept(GameController g)
    {
        g.flags[System.Int32.Parse(ID) - 10100] = true;
        sDoc.Load("Assets/Scripts/StatSaver.xml");
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p3").Value) };
        sDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = System.Math.Max(System.Math.Min(g.Anonymity + p[0], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("money").InnerText = System.Math.Max(System.Math.Min(g.Money + p[1], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("feelings").InnerText = System.Math.Max(System.Math.Min(g.Feelings + p[2], 100), 0).ToString();
        sDoc.Save("Assets/Scripts/StatSaver.xml");
    }

    public override void Decline(GameController g)
    {
        sDoc.Load("Assets/Scripts/StatSaver.xml");
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("decline").Attributes.GetNamedItem("p3").Value) };
        sDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = System.Math.Max(System.Math.Min(g.Anonymity + p[0], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("money").InnerText = System.Math.Max(System.Math.Min(g.Money + p[1], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("feelings").InnerText = System.Math.Max(System.Math.Min(g.Feelings + p[2], 100), 0).ToString();
        sDoc.Save("Assets/Scripts/StatSaver.xml");
    }
}
