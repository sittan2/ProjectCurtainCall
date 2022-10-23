using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropStove : Prop
{
    SpriteRenderer sprite;
    Animator animator;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.enabled = false;
        sprite.enabled = false;
    }
    public void On()
    {
        string command = type + "_" + number + "_" + Define.ActionType.OnOff + "_" + "1";

        Managers.UI.OnCamera(number);
        Managers.Task.DoCommand(command);

        sprite.enabled = true;
        animator.enabled = true;

        StartCoroutine(DelayDeactive());

    }

    IEnumerator DelayDeactive()
    {
        yield return new WaitForSeconds(11f);

        animator.enabled = false;
        sprite.enabled = false;
    }
}
