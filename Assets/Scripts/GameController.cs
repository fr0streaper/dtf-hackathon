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
        refresh();
    }

    private CardGen g = new CardGen();
    public GameCard curCard;

    XmlDocument d = new XmlDocument();


    public void Start()
    {
        newCard();
        refresh();
        Debug.Log("refreshed");

        d.Load("Assets/Scripts/CardCollection.xml");

        flags = new bool[d.DocumentElement.ChildNodes.Count];

        xDoc.Load("Assets/Scripts/StatSaver.xml");
        
        aPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText;
        mPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("money").InnerText;
        fPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("feelings").InnerText;
        
    }

    public void Acc ()
    {
        curCard.SceneContr = sc;
        curCard.numberOfDungeons = NumberOfDungeons;
        curCard.Accept(this);

        

        xDoc.Load("Assets/Scripts/StatSaver.xml");
        aPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText;
        mPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("money").InnerText;
        fPannel.GetComponent<Text>().text = xDoc.DocumentElement.SelectSingleNode("feelings").InnerText;
        if (xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText == "0")
        {
            aDeath();
        }
        else if (xDoc.DocumentElement.SelectSingleNode("money").InnerText == "0")
        {
            mDeath();
        }
        else if (xDoc.DocumentElement.SelectSingleNode("feelings").InnerText == "0")
        {
            fDeath();
        }
        else newCard();
    }

    public void Dec ()
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
            aDeath();
        }
        else if (xDoc.DocumentElement.SelectSingleNode("money").InnerText == "0")
        {
            mDeath();
        }
        else if (xDoc.DocumentElement.SelectSingleNode("feelings").InnerText == "0")
        {
            fDeath();
        }
        else newCard();
    }

    public void newCard()
    {
        curCard = g.getNextCard();
        Anonymity = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText);
        Money = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("money").InnerText);
        Feelings = System.Int32.Parse(xDoc.DocumentElement.SelectSingleNode("feelings").InnerText);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
        string hhh = "";
        for (int i = 0; i < flags.Length; i++)
        {
            hhh += flags[i].ToString();
        }
        Debug.Log(hhh);
    }

    public void aDeath()
    {
        curCard = new DungeGameCard("10", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
        refresh();
    }

    public void mDeath()
    {
        curCard = new DungeGameCard("11", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
        refresh();
    }

    public void fDeath()
    {
        curCard = new DungeGameCard("12", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
        refresh();
    }
    void refresh()
    {
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("money").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("feelings").InnerText = "100";
        Debug.Log(xDoc.DocumentElement.SelectSingleNode("feelings").InnerText);
        xDoc.Save("Assets/Scripts/StatSaver.xml");
    }
}
