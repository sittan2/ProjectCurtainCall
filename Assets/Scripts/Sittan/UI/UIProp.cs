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
    [SerializeField] Image Image;
    [SerializeField] Button Button;
    [SerializeField] KeyCode KeyCode = KeyCode.None;

    private void Start()
    {
        Image = GetComponent<Image>();
        Button.onClick.AddListener(Prop.SetGameManagerProp);
        Button.onClick.AddListener(() => Managers.Sound.Play(Define.SoundType.ButtonClick));
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode)) Button.onClick.Invoke();
        
        if (Input.GetKeyDown(KeyCode)) Button.onClick.Invoke();

        if (Managers.Game.selectedProp == Prop)
            Image.color = Color.gray;
        else
            Image.color = Color.white;
    }

    public void SetData(Prop prop, int index)
    {
        this.Prop = prop;
        //PropName.text = index.ToString() + ". " + Util.TranslatePropToString(prop.PropType, prop.Number);
        //Button.onClick.AddListener(prop.SetGameManagerProp);
    }
}