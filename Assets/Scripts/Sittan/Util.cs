using System.Collections;
using System.Data.Common;
using UnityEngine;
using static Define;

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
}