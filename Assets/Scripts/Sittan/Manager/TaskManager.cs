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
        float currentTime = Managers.Game.bgmPlayer.time;
        foreach (var task in tasks)
        {
            if (task.IsDone) continue;

            if (task.IsTasking)
            {
                if (task.EndTime < currentTime)
                {
                    task.FailTask();
                }
            }
            else if (task.StartTime < currentTime)
            {
                task.OnTasking();
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
        foreach (var task in tasks)
        {
            if (!task.IsTasking) continue;
            if (task.IsDone) continue;
            if (task.Command.Equals(command))
            {
                task.DoneTask();
                return;
            }
        }
    }
}