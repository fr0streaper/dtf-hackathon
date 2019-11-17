using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class WeaponController : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Granades;

    [System.NonSerialized] public Weapon weapon;
    private void Start()
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("Assets/Scripts/StatSaver.xml");
        string flags = xDoc.DocumentElement.SelectSingleNode("flags").InnerText;
        if (flags[2]=='1')
            weapon = Instantiate(Granades).GetComponent<Weapon>();
        else
            weapon = Instantiate(Rifle).GetComponent<Weapon>();
    }
    private void Update()
    {
        weapon.transform.position = transform.position + Vector3.up * 1f;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateTo(pos);
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }
    }

    private void RotateTo(Vector3 pos)
    {
        pos.z = 0;
        Vector3 dir = (pos - transform.position).normalized;
        weapon.transform.rotation = Quaternion.FromToRotation(Vector3.right, dir);
    }
}
