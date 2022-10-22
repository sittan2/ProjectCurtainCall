using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngineInternal;

public class TaskManager : MonoBehaviour
{
    [SerializeField] List<Task> tasks = new List<Task>();
    //[SerializeField] List<Task> currentTasks = new List<Task>();

    public void Init()
    {
        SetTask(Managers.Data.GamePlayData.Tasks);
    }

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
            if (task.isDone) continue;

            if (task.isTasking)
            {
                if (task.EndTime < currentTime)
                {
                    task.isDone = true;

                    Debug.Log(task.Id + ", is Time Done");
                    Managers.Game.DecreaseVeiwer(task.Value);
                }
            }
            else if (task.StartTime < currentTime)
            {
                task.isTasking = true;
                Debug.Log(task.Id + ", is Tasking");
            }
        }
    }

    public void SetTask(IReadOnlyDictionary<string, Task> tasks)
    {
        this.tasks.Clear();
        foreach (var task in tasks.Values)
        {
            this.tasks.Add(task);
        }
    }


    public void DoCommand(string command)
    {
        Debug.Log(command);

        foreach (var task in tasks)
        {
            if (!task.isTasking) continue;
            if (task.isDone) continue;

            if (task.Command.Equals(command))
            {
                task.isDone = true;
                Debug.LogError(task.Id + ", is Complete");
                Managers.Game.IncreaseViewer(task.Value);
                return;
            }
        }
    }
}