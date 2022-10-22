using System.Collections;
using UnityEngine;

public class Define
{
    public enum PropType
    {
        none = 0,
        Camera,
        Light,
    }

    public enum ActionType
    {
        none = 0,
        OnOff,
        MoveTo,
        Rotation,
        Zoom
    }
}