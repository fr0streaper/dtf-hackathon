﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public abstract class GameCard
{
    private XmlDocument xCard = new XmlDocument();
    protected XmlNode curCard;
    public string ID = "01111";


    public int Type { get; private set; }

    public Sprite Sprite1;
    public Sprite Sprite2;
    public string CardText { get; private set; }
    public string AcceptText { get; private set; }
    public string DeclineText { get; private set; }

    public GameCard(string id)
    {
        ID = id;
        xCard.Load("CardCollection.xml");
        XmlElement xRoot = xCard.DocumentElement;
        string xPath = "card[@id='" + ID + "']";
        curCard = xRoot.SelectSingleNode(xPath);

        CardText = curCard.SelectSingleNode("text").InnerText;
        AcceptText = curCard.SelectSingleNode("accept").InnerText;
        DeclineText = curCard.SelectSingleNode("decline").InnerText;

        switch (curCard.SelectSingleNode("type").InnerText)
        {
            case "green":
                Type = 0;
                break;
            case "orange":
                Type = 1;
                break;
            case "red":
                Type = 2;
                break;
        }
    }

}

