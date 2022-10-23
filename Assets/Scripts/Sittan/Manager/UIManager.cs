using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager Game;

    List<Action> actions;
    [SerializeField] List<UICommand> UICommands;
    [SerializeField] TextMeshProUGUI ViewerText;
    [SerializeField] TextMeshProUGUI ComboText;

    [SerializeField] UITask UITask;
    [SerializeField] UIProp UIProp;
    [SerializeField] UICameraView UICameraView;


    [SerializeField] Transform TaskContent;
    [SerializeField] Transform PropContent;
    [SerializeField] Transform ViewContent;

    [SerializeField] UICameraView mainCamera;
    [SerializeField] List<UICameraView> SubCameras;

    public void Init()
    {
        Game = Managers.Game;

        actions = new List<Action>();
        GameObject.Find("Prop").GetComponentsInChildren<Prop>(true).ToList().ForEach(prop => AddPropButton(prop));
        GameObject.Find("Prop").GetComponentsInChildren<PropCamera>(true).ToList().ForEach(prop => AddCameraView(prop));
        OnCamera(1);
    }
    

    private void Update()
    {
        if (ViewerText != null) ViewerText.text = Managers.Game.viewer.ToString();
        if (ComboText != null) ComboText.text = Managers.Game.combo.ToString();

        //for (int i = 0; i < 10; i++)
        //{
        //    if (Input.GetKeyDown((KeyCode)(48 + i))
        //}

        //if (Input.GetKeyDown((KeyCode)49)) actions.FindIndex(1)



    }

    public UITask AddTaskUI(Task task)
    {
        var UITask = Instantiate(this.UITask, TaskContent);
        UITask.SetData(task);
        return UITask;
    }

    public void AddPropButton(Prop prop)
    {
        //var UIProp = Instantiate(this.UIProp, PropContent);
        //UIProp.SetData(prop, actions.Count + 1);

        //Action action = prop.SetGameManagerProp;
        //actions.Add(action);
    }

    public void AddCameraView(PropCamera prop)
    {
        var UICameraView = Instantiate(this.UICameraView, ViewContent);
        UICameraView.SetData(prop);
        SubCameras.Add(UICameraView);
    }

    public void OnCamera(int num)
    {
        for (int i = 0; i < SubCameras.Count; i++)
        {
            if (i == num - 1)
            {
                SubCameras[i].gameObject.SetActive(false);
                mainCamera.SetTexture(SubCameras[i].GetTexture());
            }
            else
                SubCameras[i].gameObject.SetActive(true);
        }
    }

    public void RefreshCommandUI(Prop prop)
    {
        if (prop != null)
        {
            for (int i = 0; i < UICommands.Count; i++)
            {
                int index = i;
                UICommands[index].SetData(prop.commands[index].commandName, () => prop.commands[index].command?.Invoke());
            }
        }
    }
}