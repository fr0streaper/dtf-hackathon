using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class GameController : MonoBehaviour
{
    public int Anonymity = 100;
    public int Money = 100;
    public int Feelings = 100;

    public bool[] flags;

    public GameObject tCard;
    public GameObject tAcc;
    public GameObject tDec;
    public GameObject aButton;
    public GameObject dButton;
    public GameObject aPannel;
    public GameObject mPannel;
    public GameObject fPannel;
    public ScenesController sc;
    public int NumberOfDungeons;

    XmlDocument xDoc = new XmlDocument();
    public GameController()
    {
        Anonymity = 100;
        Money = 100;
        Feelings = 100;
    }

    private CardGen g = new CardGen();
    public GameCard curCard;
    public bool isDangOrDeathCard = false;
    XmlDocument d = new XmlDocument();


    public void Start()
    {
        refresh();
        d.Load("Assets/Scripts/CardCollection.xml");
        flags = new bool[d.DocumentElement.ChildNodes.Count];
        newCard();

        xDoc.Load("Assets/Scripts/StatSaver.xml");

        xDoc.Save("Assets/Scripts/StatSaver.xml");

        aPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText;
        mPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("money").InnerText;
        fPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("feelings").InnerText;
        
    }

    public void Acc()
    {
        
        curCard.SceneContr = sc;
        curCard.numberOfDungeons = NumberOfDungeons;
        curCard.Accept(this);
        
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        xDoc.DocumentElement.SelectSingleNode("flags").InnerText = boolToString(this.flags);
        xDoc.Save("Assets/Scripts/StatSaver.xml");

        xDoc.Load("Assets/Scripts/StatSaver.xml");
        aPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText;
        mPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("money").InnerText;
        fPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("feelings").InnerText;
        
        if (xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText == "0")
        {
            Death("10");
        }
        else if (xDoc.DocumentElement.SelectSingleNode("money").InnerText == "0")
        {
            Death("11");
        }
        else if (xDoc.DocumentElement.SelectSingleNode("feelings").InnerText == "0")
        {
            Death("12");
        }
        else if(!isDangOrDeathCard) newCard();
    }

    public void Dec()
    {
        curCard.SceneContr = sc;
        curCard.numberOfDungeons = NumberOfDungeons;
        curCard.Decline(this);

        xDoc.Load("Assets/Scripts/StatSaver.xml");


        aPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText;
        mPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("money").InnerText;
        fPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("feelings").InnerText;

        if (xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText == "0")
        {
            Death("10");
        }
        else if (xDoc.DocumentElement.SelectSingleNode("money").InnerText == "0")
        {
            Death("11");
        }
        else if (xDoc.DocumentElement.SelectSingleNode("feelings").InnerText == "0")
        {
            Death("12");
        }
        else if(!isDangOrDeathCard) newCard();
    }

    public void newCard()
    {
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        if (xDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText == "1")
        {
            string s = xDoc.DocumentElement.SelectSingleNode("flags").InnerText;
            for (int i = 0; i < s.Length; i++)
            {
                flags[i] = (s[i] == '1');
            }
            xDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText = "0";
            xDoc.DocumentElement.SelectSingleNode("flags").InnerText = "";

            
            xDoc.Load("Assets/Scripts/StatSaver.xml");
        }
        Anonymity = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText);
        Money = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("money").InnerText);
        Feelings = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("feelings").InnerText);
        isDangOrDeathCard = false;
        curCard = g.getNextCard();
        tRefr();
    }

    public void Death(string ind)
    {
        isDangOrDeathCard = true;
        curCard = new DungeGameCard(ind, "DeathCards", 2, 2);
        tRefr();
        xDoc.Load("Assets/Scripts/StatSaver.xml");

        xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("money").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("feelings").InnerText = "100";

        Debug.Log(xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText);

        xDoc.Save("Assets/Scripts/StatSaver.xml");
    }

    void tRefr()
    {
        //Debug.Log("Log");
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
    }
    void refresh()
    {
        //if (isDangOrDeathCard) return;
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        if (xDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText == "0")
        {
            xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = "100";
            xDoc.DocumentElement.SelectSingleNode("money").InnerText = "100";
            xDoc.DocumentElement.SelectSingleNode("feelings").InnerText = "100";
        }
        xDoc.DocumentElement.SelectSingleNode("flagssaved").InnerText = "0";
        xDoc.Save("Assets/Scripts/StatSaver.xml");
    }

    string boolToString(bool[] f)
    {
        string ans = "";
        for (int i = 0; i < f.Length; i++)
        {
            if (f[i]) ans += "1";
            else ans += "0";
        }
        return ans;
    }
}
