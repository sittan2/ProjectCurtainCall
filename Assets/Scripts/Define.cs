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

    public enum SoundType
    {
        none = 0,
        ButtonClick = 10,
        LightOn,
        LightOff,
        Lens,
        CameraOn,
        Combo1,
        Combo2,
        Biff,
        GameOver1,
        GameOver2,
    }
}