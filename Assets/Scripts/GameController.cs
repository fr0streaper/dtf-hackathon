using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Anonymity = 100;
    public int Money = 100;
    public int Feelings = 100;

    public string CardText { get; set; }
    public string AcceptText;
    public string DeclineText;

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

    public GameController()
    {
        Anonymity = 100;
        Money = 100;
        Feelings = 100;
    }

    private CardGen g = new CardGen();
    public GameCard curCard;
    public void Start()
    {
        newCard();
        aPannel.GetComponent<Text>().text = "100";
        mPannel.GetComponent<Text>().text = "100";
        fPannel.GetComponent<Text>().text = "100";
    }

    public void Acc ()
    {
        curCard.SceneContr = sc;
        curCard.numberOfDungeons = NumberOfDungeons;
        curCard.Accept(this);
        aPannel.GetComponent<Text>().text = this.Anonymity.ToString();
        mPannel.GetComponent<Text>().text = this.Money.ToString();
        fPannel.GetComponent<Text>().text = this.Feelings.ToString();
        if (this.Anonymity <= 0)
        {
            aDeath();
        } else if (this.Money <= 0)
        {
            mDeath();
        } else if (this.Feelings <= 0)
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
        aPannel.GetComponent<Text>().text = this.Anonymity.ToString();
        mPannel.GetComponent<Text>().text = this.Money.ToString();
        fPannel.GetComponent<Text>().text = this.Feelings.ToString();
        if (this.Anonymity <= 0)
        {
            aDeath();
        }
        else if (this.Money <= 0)
        {
            mDeath();
        }
        else if (this.Feelings <= 0)
        {
            fDeath();
        }
        else newCard();
    }

    public void newCard()
    {
        curCard = g.getNextCard();
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
    }

    public void aDeath()
    {
        curCard = new DungeGameCard("10", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
    }

    public void mDeath()
    {
        curCard = new DungeGameCard("11", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
    }

    public void fDeath()
    {
        curCard = new DungeGameCard("12", "DeathCards", 2, 2);
        tCard.GetComponent<Text>().text = curCard.CardText;
        tAcc.GetComponent<Text>().text = curCard.AcceptText;
        tDec.GetComponent<Text>().text = curCard.DeclineText;
    }
}
