using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Command> commands;
    [SerializeField] protected Define.PropType type;
    [SerializeField] protected int number;

    public Define.PropType PropType => type;
    public int Number => number;

    private void Awake()
    {
        commands = GetComponents<Command>().ToList();
    }

    public void SetGameManagerProp()
    {
        Managers.Game.SetSelectedProp(this);
    }
}
