using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLight : Prop
{
    public void On()
    {
        Debug.Log("Light On");

        string command = type + "_" + number + "_" + "On" + "_" + "1";

        Managers.Task.DoCommand(command);
    }

    public void Off()
    {
        Debug.Log("Light Off");

        string command = type + "_" + number + "_" + "On" + "_" + "0";

        Managers.Task.DoCommand(command);
    }
}
