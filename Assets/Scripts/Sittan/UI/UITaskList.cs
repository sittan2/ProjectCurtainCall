using System.Collections;
using UnityEngine;

public class UITaskList : MonoBehaviour
{
    [SerializeField] UITask UITask;
    [SerializeField] Transform Content;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddTask(Task task)
    {
        Instantiate(UITask, Content);
    }
}