using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Command> commands;
    [SerializeField] protected Define.PropType type;
    [SerializeField] protected int number;

    public void SetGameManagerProp()
    {
        Managers.Game.SetSelectedProp(this);
    }
}
