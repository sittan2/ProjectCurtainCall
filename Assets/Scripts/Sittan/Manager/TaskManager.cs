using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    IReadOnlyDictionary<string, Task> tasks;
    List<Task> currentTasks = new List<Task>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        if (Input.GetKeyDown(KeyCode.W))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }


        float currentTime = Managers.Game.bgmPlayer.time;
        foreach (var task in tasks)
        {
            //if ()
        }
    }

    public void SetTask(IReadOnlyDictionary<string, Task> tasks)
    {
        if (tasks == null)
        {
            
        }
    }


    public void DoCommand(string command)
    {

    }
}