using System;
using System.Collections;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProp : MonoBehaviour
{
    [SerializeField] Prop Prop;
    [SerializeField] TextMeshProUGUI PropName;
    [SerializeField] Button Button;

    public void SetData(Prop prop, int index)
    {
        this.Prop = prop;
        PropName.text = index.ToString() + ". " + Util.TranslatePropToString(prop.PropType, prop.Number);
        Button.onClick.AddListener(prop.SetGameManagerProp);
    }
}