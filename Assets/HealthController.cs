using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class HealthController : MonoBehaviour
{
    public GameObject RIP;
    public GameObject YouDiedText;
    public int Health;

    private XmlDocument xDoc;
    void ApplyDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            if(tag == "Player")
            {
                PlayerDie();
            }
            Instantiate(RIP).transform.position = transform.position;
            Destroy(gameObject);
        }

    }
    void PlayerDie()
    {
        Transform text = Instantiate(YouDiedText).transform;
        text.parent = FindObjectOfType<Canvas>().transform;
        text.transform.localPosition = Vector3.zero;
        xDoc = new XmlDocument();
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        xDoc.DocumentElement.SelectSingleNode("anonymity").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("money").InnerText = "100";
        xDoc.DocumentElement.SelectSingleNode("feelings").InnerText = "100";
        xDoc.Save("Assets/Scripts/StatSaver.xml");
        FindObjectOfType<ScenesController>().FadeOutTo(0);
    }
}
