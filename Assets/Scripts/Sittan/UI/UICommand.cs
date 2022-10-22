using System;
using System.Collections;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UICommand : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] Button Button;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] KeyCode KeyCode = KeyCode.None;
    float time;

    private void Start()
    {
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();
        if (Text == null) GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode)) Button.onClick.Invoke();
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
            Image.color = Color.white;
        }
    }

    void ClickButton()
    {
        Managers.Sound.Play(Define.SoundType.ButtonClick);
        time += 0.2f;
        Image.color = Color.gray;
    }

    public void SetData(string command, UnityAction action)
    {
        Text.text = command;
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(ClickButton);
        Button.onClick.AddListener(action);
    }
}