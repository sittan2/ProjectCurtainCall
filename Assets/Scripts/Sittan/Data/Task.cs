using System.Collections;
using UnityEngine;

[System.Serializable]
public class Task
{
    [SerializeField] string command;
    [SerializeField] float startTime;
    //[SerializeField] float preJudgeTime;
    //[SerializeField] float postJudgeTime;

    public Task(float startTime)
    {
        this.startTime = startTime;
    }
}