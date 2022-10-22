using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Command : MonoBehaviour
{
    [SerializeField] public UnityEvent command;
    [SerializeField] public string commandName = "";
}
