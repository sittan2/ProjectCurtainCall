using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropStove : Prop
{
    public void On()
    {
        string command = type + "_" + number + "_" + Define.ActionType.OnOff + "_" + "1";

        Managers.UI.OnCamera(number);
        Managers.Task.DoCommand(command);

        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(DelayDeactive());
    }

    IEnumerator DelayDeactive()
    {
        yield return new WaitForSeconds(11f);

        gameObject.SetActive(false);
    }
}
