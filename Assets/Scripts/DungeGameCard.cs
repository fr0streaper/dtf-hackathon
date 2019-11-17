using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Security.Cryptography;

class DungeGameCard : GameCard
{
    public int aD, dD;

    public int x;

    XmlDocument sDoc = new XmlDocument();
    public DungeGameCard(string id, string filename, int ad, int dd) : base(id, filename) { aD = ad; dD = dd; }

    public override void Accept(GameController g)
    {
        
        if (aD != 2) g.flags[System.Int32.Parse(ID) - 10100] = true;
        sDoc.Load("Assets/Scripts/StatSaver.xml");
        int[] p = {System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p1").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p2").Value),
            System.Int32.Parse(curCard.SelectSingleNode("accept").Attributes.GetNamedItem("p3").Value) };
        sDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = System.Math.Max(System.Math.Min(g.Anonymity + p[0], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("money").InnerText = System.Math.Max(System.Math.Min(g.Money + p[1], 100), 0).ToString();
        sDoc.DocumentElement.SelectSingleNode("feelings").InnerText = System.Math.Max(System.Math.Min(g.Feelings + p[2], 100), 0).ToString();
        sDoc.Save("Assets/Scripts/StatSaver.xml");

        

        if (aD == 1)
        {
            g.isDangOrDeathCard = true;
            refrX();
            sDoc.Load("Assets/Scripts/StatSaver.xml");
            sDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText = "1";
            sDoc.Save("Assets/Scripts/StatSaver.xml");
            SceneContr.FadeOutTo(x);
        }
        if  (aD == 2)
        {
            g.isDangOrDeathCard = true;
            SceneContr.FadeOutTo(0);
        }
        
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
        if (dD == 1)
        {
            g.isDangOrDeathCard = true;
            refrX();
            sDoc.Load("Assets/Scripts/StatSaver.xml");
            sDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText = "1";
            sDoc.Save("Assets/Scripts/StatSaver.xml");
            SceneContr.FadeOutTo(x);
        }
        if (dD == 2)
        {
            g.isDangOrDeathCard = true;
            SceneContr.FadeOutTo(0);
        }
    }

    void refrX()
    {
        using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
        {
            byte[] rno = new byte[5];
            rg.GetBytes(rno);
            x = System.BitConverter.ToInt32(rno, 0);
        }
        x = System.Math.Abs(x);
        x = 2 + x % numberOfDungeons;
    }


}

