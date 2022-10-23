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
    [SerializeField] float judgeTime;
    [SerializeField] float judgeEndTime;
    [SerializeField] int value;
    [SerializeField] Define.PropType propType;
    [SerializeField] int number;
    [SerializeField] Define.ActionType actionType;
    [SerializeField] int parameter;

    [SerializeField] float endTime;
    [SerializeField] bool isTasking = false;
    [SerializeField] bool isDone = false;
    [SerializeField] UITask ui;

    public Task(string id, float intervalTime, float judgeTime, int value, Define.PropType propType, int number, Define.ActionType actionType, int parameter)
    {
        this.id = id;
        this.intervalTime = intervalTime;
        this.judgeTime = judgeTime;
        this.value = value;
        this.propType = propType;
        this.number = number;
        this.actionType = actionType;
        this.parameter = parameter;

        startTime = judgeTime - intervalTime;
        judgeEndTime = judgeTime + 1;
        endTime = judgeTime + 2;
        command = PropType.ToString() + "_" + number + "_" + ActionType.ToString() + "_" + parameter;
    }

    public string Id => id;
    public string Command => command;
    public float StartTime => startTime;
    public float IntervalTime => intervalTime;
    public float JudgeTime => judgeTime;
    public float JudgeEndTime => judgeEndTime;
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

    public void PerfectDoneTask()
    {
        isDone = true;
        Managers.Game.IncreaseViewer(Value, true);
        ui.DoneTask();
        ui = null;
        Debug.Log("Perfect");
    }

    public void DoneTask()
    {
        isDone = true;
        Managers.Game.IncreaseViewer(Value);
        ui.DoneTask();
        ui = null;
        Debug.Log("Done");
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