using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

[System.Serializable]
public class Task
{
    [SerializeField] string command;
    [SerializeField] float startTime;
    [SerializeField] float intervalTime;
    [SerializeField] int value;
    [SerializeField] Define.PropType propType;
    [SerializeField] int number;
    [SerializeField] Define.ActionType actionType;
    [SerializeField] int parameter;


    public Task(float startTime, float intervalTime, int value, Define.PropType propType, int number, Define.ActionType actionType, int parameter)
    {
        this.startTime = startTime;
        this.intervalTime = intervalTime;
        this.value = value;
        this.propType = propType;
        this.number = number;
        this.actionType = actionType;
        this.parameter = parameter;
    }

    public string Command => command;
    public float StartTime => startTime;
    public int Value => value;
    public Define.PropType PropType => propType;
    public int Number => number;
    public Define.ActionType ActionType => actionType;
    public int Parameter => parameter;
}