using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TestAction : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;


    // Use this for initialization
    void Start()
    {
        unityEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
}