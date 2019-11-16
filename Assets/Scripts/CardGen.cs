using System;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;
using UnityEngine;

public class CardGen
{
    private XmlDocument xDoc = new XmlDocument();
    private XmlElement xRoot;

    uint cardsAtAll = 0;

    List<string> allID = new List<string>();

    Dictionary<string, int> uId = new Dictionary<string, int>();

    string prevcard = "101110111";

    public CardGen()
    {
        xDoc.Load("CardCollection.xml");
        xRoot = xDoc.DocumentElement;
        cardsAtAll = (uint)xRoot.ChildNodes.Count;
        foreach (XmlNode h in xRoot.ChildNodes)
        {
            string id = h.Attributes.GetNamedItem("id").Value;
            string s = h.SelectSingleNode("descriptor").InnerText;
            allID.Add(id);
            uId[id] = 0;
        }
    }

    bool checker(char a, char b, char c, char d, char neutral = '1')
    {
        if (a == neutral && b == neutral && c == neutral && d == neutral) { return true; }
        if (a != c) return true;
        if (a != d) return true;
        if (b != c) return true;
        if (b != d) return true;
        return false;
    }
    public string getNextCard()
    {

        int rej = -1;
        string ans, cD;

        while (true)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                uint x = BitConverter.ToUInt32(rno, 0);

                x = x % (cardsAtAll);

                rej++;

                //Console.Write(allID[(int)x] + " ");

                string xPath = "card[@id='" + allID[(int)x] + "']";
                cD = xRoot.SelectSingleNode(xPath).SelectSingleNode("descriptor").InnerText; //candidatesDescriptor
                int diff = 0;

                if (uId[allID[(int)x]] > 2 * rej)
                {
                    //Console.WriteLine("used " + rej.ToString() + " " + uId[allID[(int)x]].ToString());
                    continue;
                }

                if (cD[0] != prevcard[0]) { diff++; }
                if (checker(cD[1], cD[5], prevcard[1], prevcard[5], '0')) { diff++; } //check D
                if (checker(cD[2], cD[6], prevcard[2], prevcard[6])) { diff++; } //check A
                if (checker(cD[3], cD[7], prevcard[3], prevcard[7])) { diff++; } //check M
                if (checker(cD[4], cD[8], prevcard[4], prevcard[8])) { diff++; } //check F

                if (diff >= 0)
                {
                    ans = allID[(int)x];
                    break;
                }
                //else Console.Write(" rejected ");
            }
        }

        uId[ans]++;
        prevcard = cD;
        return ans;
    }
}
