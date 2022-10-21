using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GamePlayData
{
    Dictionary<string, Task> TaskDictionary;
    public IReadOnlyDictionary<string, Task> Tasks => TaskDictionary;

    public GamePlayData(Dictionary<string, Task> taskDic)
    {
        TaskDictionary = taskDic;
    }
}