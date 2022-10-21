using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    #region Managers
    #endregion


}
