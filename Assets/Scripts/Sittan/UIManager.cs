using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameManager Game;
    
    [SerializeField] UITaskList UITaskList;


    public void Init()
    {
        Game = Managers.Game;
        CreateTask();
    }

    private void Update()
    {
        
    }

    IEnumerable Tasking()
    {
        var tasks = Managers.Data.GamePlayData.Tasks;

        while (true)
        {

        }
    }

    private void CreateTask()
    {
        var tasks = Managers.Data.GamePlayData.Tasks;

        foreach (var task in tasks.Values)
        {
            UITaskList.AddTask(task);
        }
    }
}