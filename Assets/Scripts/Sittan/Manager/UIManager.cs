using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager Game;

    List<Action> actions;
    [SerializeField] List<Button> UICommands = new List<Button>();
    [SerializeField] TextMeshProUGUI ViewerText;
    [SerializeField] UITask UITask;
    [SerializeField] UIProp UIProp;

    [SerializeField] Transform TaskContent;
    [SerializeField] Transform PropContent;

    public void Init()
    {
        Game = Managers.Game;

        actions = new List<Action>();
    }

    private void Update()
    {
        if (ViewerText != null) ViewerText.text = Managers.Game.viewer.ToString();

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
        var UIProp = Instantiate(this.UIProp, PropContent);
        UIProp.SetData(prop, actions.Count + 1);

        Action action = prop.SetGameManagerProp;
        actions.Add(action);
    }

    public void RefreshCommandUI(Prop prop)
    {
        foreach (var UICommand in UICommands)
        {
            UICommand.onClick.RemoveAllListeners();
            UICommand.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }

        if (prop != null)
        {
            
            for (int i = 0; i < UICommands.Count; i++)
            {
                int index = i;
                UICommands[index].onClick.AddListener(() => prop.commands[index].command?.Invoke());
                UICommands[index].GetComponentInChildren<TextMeshProUGUI>().text = prop.commands[index].commandName;
            }
        }
    }
}