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
    }

    public void ZoomOut()
    {
        var position = gameObject.transform.position;

        position.z += 10;

        gameObject.transform.position = position;
    }

    public void MoveToOne()
    {
        gameObject.transform.position = positions[0];
        gameObject.transform.rotation = Quaternion.Euler(rotations[0]);
    }

    public void MoveToTwo()
    {
        gameObject.transform.position = positions[1];
        gameObject.transform.rotation = Quaternion.Euler(rotations[1]);
    }

    public void MoveToThree()
    {
        gameObject.transform.position = positions[2];
        gameObject.transform.rotation = Quaternion.Euler(rotations[2]);
    }

    public void On()
    {
        Debug.Log("On");
    }
}
