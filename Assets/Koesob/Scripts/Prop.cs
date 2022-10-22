using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Command> commands;

    public void SetGameManagerProp()
    {
        Managers.Game.SetSelectedProp(this);
    }
}
