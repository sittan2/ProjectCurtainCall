using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager Game;
    
    [SerializeField] UITaskList UITaskList;
    [SerializeField] List<Button> UICommands = new List<Button>();
    [SerializeField] TextMeshProUGUI ViewerText;

    public void Init()
    {
        Game = Managers.Game;
        CreateTask();
    }

    private void Update()
    {
        if (ViewerText != null) ViewerText.text = Managers.Game.viewer.ToString();
    }

    private void CreateTask()
    {
        var tasks = Managers.Data.GamePlayData.Tasks;

        foreach (var task in tasks.Values)
        {
            UITaskList.AddTask(task);
        }
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