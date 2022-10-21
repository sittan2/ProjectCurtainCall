using System.Collections;
using UnityEngine;

[System.Serializable]
public class Task
{
    [SerializeField] string command;
    [SerializeField] float startTime;
    //[SerializeField] float preJudgeTime;
    //[SerializeField] float postJudgeTime;
    [SerializeField] int value;

    public Task(float startTime)
    {
        this.startTime = startTime;
        this.value = 10;
    }

    public string Command => command;
    public float StartTime => startTime;
    public int Value => value;
}