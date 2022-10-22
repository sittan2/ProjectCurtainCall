using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        Debug.Log(prop.name + ", " + prop.commands.Count);

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
                UICommands[index].onClick.AddListener(() => Debug.Log("Add"));
                UICommands[index].onClick.AddListener(() => prop.commands[index].command?.Invoke());
                UICommands[index].GetComponentInChildren<TextMeshProUGUI>().text = prop.commands[index].commandName;
            }
        }
    }
}