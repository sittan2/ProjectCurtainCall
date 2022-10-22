using System.Collections;
using System.Data.Common;
using UnityEngine;

public class Util
{
    public static string TranslateActionToString(Define.ActionType actionType, int parameter)
    {
        string action = "";
        switch (actionType)
        {
            case Define.ActionType.OnOff:
                if (parameter == 0)
                    action = "끄기";
                else if (parameter == 1)
                    action = "켜기";
                break;

            case Define.ActionType.MoveTo:
                if (parameter == 1)
                    action = "A로 이동";
                else if (parameter == 2)
                    action = "B로 이동";
                else if (parameter == 3)
                    action = "C로 이동";
                break;

            case Define.ActionType.Rotation:
                if (parameter == 0)
                    action = "고정";
                else if (parameter == 1)
                    action = "회전";
                break;

            case Define.ActionType.Zoom:
                if (parameter == 0)
                    action = "줌 인";
                else if (parameter == 1)
                    action = "줌 아웃";
                break;
        }
        return action;
    }

    public static string TranslatePropToString(Define.PropType propType, int number)
    {
        string prop = "";
        switch (propType)
        {
            case Define.PropType.Camera:
                prop += "카메라";
                break;
            case Define.PropType.Light:
                prop += "조명";
                break;
        }
        prop += $" {number}번";

        return prop;
    }
}