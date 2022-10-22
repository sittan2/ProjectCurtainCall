using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCamera : Prop
{
    public List<Vector3> rotations;

    public void ZoomIn()
    {
        var position = gameObject.transform.position;

        position.z -= 10;

        gameObject.transform.position = position;

        string command = type + "_" + number + "_" + "Zoom" + "_" + "0";

        Managers.Task.DoCommand(command);
    }

    public void ZoomOut()
    {
        var position = gameObject.transform.position;

        position.z += 10;

        gameObject.transform.position = position;

        string command = type + "_" + number + "_" + "Zoom" + "_" + "1";

        Managers.Task.DoCommand(command);
    }

    public void MoveToOne()
    {
        gameObject.transform.position = positions[0];
        gameObject.transform.rotation = Quaternion.Euler(rotations[0]);

        string command = type + "_" + number + "_" + "MoveTo" + "_" + "1";

        Managers.Task.DoCommand(command);
    }

    public void MoveToTwo()
    {
        gameObject.transform.position = positions[1];
        gameObject.transform.rotation = Quaternion.Euler(rotations[1]);

        string command = type + "_" + number + "_" + "MoveTo" + "_" + "2";

        Managers.Task.DoCommand(command);
    }

    public void MoveToThree()
    {
        gameObject.transform.position = positions[2];
        gameObject.transform.rotation = Quaternion.Euler(rotations[2]);

        string command = type + "_" + number + "_" + "MoveTo" + "_" + "3";

        Managers.Task.DoCommand(command);
    }

    public void On()
    {
        Debug.Log("On");

        string command = type + "_" + number + "_" + "OnOff" + "_" + "1";

        Managers.Task.DoCommand(command);
    }
}
