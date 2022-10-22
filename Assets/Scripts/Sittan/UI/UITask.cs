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

    void Update()
    {
        CalculateScrollbar();
    }

    public void SetData(Task task)
    {
        this.Task = task;
        this.scrollbar.size = 1;
        this.TextDescript.text = task.Command;
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
}
