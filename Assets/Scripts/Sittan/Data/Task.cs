using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

[System.Serializable]
public class Task
{
    [SerializeField] string id;
    [SerializeField] string command;
    [SerializeField] float startTime;
    [SerializeField] float intervalTime;
    [SerializeField] int value;
    [SerializeField] Define.PropType propType;
    [SerializeField] int number;
    [SerializeField] Define.ActionType actionType;
    [SerializeField] int parameter;

    [SerializeField] float endTime;
    [SerializeField] bool isTasking = false;
    [SerializeField] bool isDone = false;
    [SerializeField] UITask ui;

    public Task(string id, float startTime, float intervalTime, int value, Define.PropType propType, int number, Define.ActionType actionType, int parameter)
    {
        this.id = id;
        this.startTime = startTime;
        this.intervalTime = intervalTime;
        this.value = value;
        this.propType = propType;
        this.number = number;
        this.actionType = actionType;
        this.parameter = parameter;

        endTime = startTime + intervalTime;
        command = PropType.ToString() + "_" + number + "_" + ActionType.ToString() + "_" + parameter;
    }

    public string Id => id;
    public string Command => command;
    public float StartTime => startTime;
    public float IntervalTime => intervalTime;
    public float EndTime => endTime;
    public int Value => value;
    public Define.PropType PropType => propType;
    public int Number => number;
    public Define.ActionType ActionType => actionType;
    public int Parameter => parameter;

    public bool IsTasking => isTasking;
    public bool IsDone => isDone;

    public void OnTasking()
    {
        isTasking = true;
        ui = Managers.UI.AddTaskUI(this);
    }
    public void DoneTask()
    {
        isDone = true;
        Managers.Game.IncreaseViewer(Value);
        ui.DoneTask();
        ui = null;
    }

    public void FailTask()
    {
        isDone = true;
        Managers.Game.DecreaseVeiwer(Value);
        ui.FailTask();
        ui = null;
    }

    public string GetDescript()
    {
        string prop = "";
        switch (propType)
        {
            case Define.PropType.Camera:
                prop = "카메라";
                break;
            case Define.PropType.Light:
                prop = "조명";
                break;
        }

        string num = " " + number.ToString() + " - ";

        string action = Util.TranslateActionToString(ActionType, Parameter);

        return prop + num + action;
    }

}