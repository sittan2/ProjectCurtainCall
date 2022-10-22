using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager Game;
    
    [SerializeField] List<Button> UICommands = new List<Button>();
    [SerializeField] TextMeshProUGUI ViewerText;
    [SerializeField] UITask UITask;
    [SerializeField] Transform TaskContent;

    public void Init()
    {
        Game = Managers.Game;
    }

    private void Update()
    {
        if (ViewerText != null) ViewerText.text = Managers.Game.viewer.ToString();
    }

    public UITask AddTaskUI(Task task)
    {
        var UITask = Instantiate(this.UITask, TaskContent);
        UITask.SetData(task);
        return UITask;
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