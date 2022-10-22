using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLight : Prop
{
    [SerializeField] GameObject triangleLight;

    public void On()
    {
        Debug.Log("Light On");

        triangleLight.SetActive(true);

        string command = type + "_" + number + "_" + Define.ActionType.OnOff + "_" + "1";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.LightOn);
    }

    public void Off()
    {
        Debug.Log("Light Off");

        triangleLight.SetActive(false);

        string command = type + "_" + number + "_" + Define.ActionType.OnOff + "_" + "0";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.LightOff);
    }
}
