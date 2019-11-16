using System;
using System.Collections.Generic;
using System.Xml;

public class CardGen
{
    private XmlDocument xDoc = new XmlDocument();
    private XmlElement xRoot;

    int cardsAtAll = 0;

    /*List<string>[] C = new List<string>[3];
    List<string>[] D = new List<string>[2];
    List<string>[] A = new List<string>[3];
    List<string>[] M = new List<string>[3];
    List<string>[] F = new List<string>[3];*/

    List<string> allID;

    Dictionary<string, int> uId;

    string prevcard = "101110111";

    public CardGen()
    {
        xDoc.Load("./CardCollection.xml");
        xRoot = xDoc.DocumentElement;
        cardsAtAll = xRoot.ChildNodes.Count;
        foreach (XmlNode h in xRoot.ChildNodes)
        {
            string id = h.Attributes.GetNamedItem("id").Value;
            string s = h.SelectSingleNode("descriptor").InnerText;
            allID.Add(id);

            /*C[s[0] - '0'].Add(id);

            D[s[1] - '0'].Add(id);
            A[s[2] - '0'].Add(id);
            M[s[3] - '0'].Add(id);
            F[s[4] - '0'].Add(id);

            D[s[5] - '0'].Add(id);
            A[s[6] - '0'].Add(id);
            M[s[7] - '0'].Add(id);
            F[s[8] - '0'].Add(id);*/
        }
    }

    bool checker(char a, char b, char c, char d, char neutral = '1')
    {
        if(a == neutral && b == neutral && c == neutral && d == neutral) { return true; }
        if (a != c) return true;
        if (a != d) return true;
        if (b != c) return true;
        if (b != d) return true;
        return false;
    }
    string getNextCard()
    {
        Random rand = new Random();
        int rej = -1;
        string ans, cD;

        while (true)
        {
            int x = rand.Next(0, cardsAtAll);
            rej++;
            cD = xRoot.SelectSingleNode(allID[x]).SelectSingleNode("descriptor").InnerText; //candidatesDescriptor
            int diff = 0;

            if (uId[allID[x]] > rej % cardsAtAll) continue;

            if (cD[0] != prevcard[0]) { diff++; }
            if (checker(cD[1], cD[5], prevcard[1], prevcard[5], '0')) { diff++; } //check D
            if (checker(cD[2], cD[6], prevcard[2], prevcard[6])) { diff++; } //check A
            if (checker(cD[3], cD[7], prevcard[3], prevcard[7])) { diff++; } //check M
            if (checker(cD[4], cD[8], prevcard[4], prevcard[8])) { diff++; } //check F

            if (diff >= 4)
            {
                ans = allID[x];
                break;
            }
        }

        uId[ans]++;
        prevcard = cD;
        return ans;
    }
}
