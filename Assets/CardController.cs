using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class CardController : MonoBehaviour
{
    private XmlDocument xCard = new XmlDocument();
    public int ID = 0;
    private void Start()
    {
        xCard.Load("./Assets/CardCollection.xml");
        XmlElement xRoot = xCard.DocumentElement;
        foreach (XmlElement xnode in xRoot)
        {
            XmlNode attr = xnode.Attributes.GetNamedItem("id");
            Debug.Log(attr.Value);
        }
    }
    
    
}
