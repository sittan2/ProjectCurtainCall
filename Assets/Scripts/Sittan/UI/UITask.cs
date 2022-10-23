using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITask : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI TextDescript;
    [SerializeField] Scrollbar scrollbar;
    [SerializeField] Task Task;
    [SerializeField] RectTransform judgeZone;

    void Update()
    {
        CalculateScrollbar();
    }

    public void SetData(Task task)
    {
        this.Task = task;
        this.scrollbar.size = 1;
        this.TextDescript.text = task.GetDescript();
        SetPerfectZone();
    }

    public void DoneTask()
    {
        Destroy(gameObject);
    }

    public void FailTask()
    {
        Destroy(gameObject);
    }

    void CalculateScrollbar()
    {
        var restTime = Task.EndTime - Managers.Game.bgmPlayer.time;
        if (restTime > 0)
        {
            var persent = restTime / Task.IntervalTime;
            scrollbar.size = persent;
            if (persent > 0.4f)
            {
                scrollbar.handleRect.GetComponent<Image>().color = Color.green;
            }
            else
            {
                scrollbar.handleRect.GetComponent<Image>().color = Color.yellow;
            }
        }
        else
            scrollbar.size = 0;
    }

    void SetPerfectZone()
    {
        var totalTime = Task.EndTime - Task.StartTime;
        var judgeTime = Task.JudgeEndTime - Task.JudgeTime;
        var judgeRate = judgeTime / totalTime;

        var totalWidth = judgeZone.parent.GetComponent<RectTransform>().rect.width;
        var judgeWidth = totalWidth * judgeRate;

        var judgeMiddleTime = judgeTime / 2 + (Task.EndTime - Task.JudgeEndTime);
        var judgePosRate = judgeMiddleTime / totalTime;
        var judgePosition = totalWidth * judgePosRate;

        judgeZone.sizeDelta = new Vector2(judgeWidth, judgeZone.sizeDelta.y);
        judgeZone.anchoredPosition = new Vector2(judgePosition, 0);
    }
}
