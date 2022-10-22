using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager Game;
    
    [SerializeField] UITaskList UITaskList;
    [SerializeField] List<Button> UICommands = new List<Button>();

    public void Init()
    {
        Game = Managers.Game;
        CreateTask();
    }

    private void Update()
    {

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
        }

        for (int i = 0; i < UICommands.Count; i++)
        {
            UICommands[i].onClick.RemoveAllListeners();
            //if (prop.commands[i].)
            //UICommands[i].onClick.AddListener()
        }
    }
}