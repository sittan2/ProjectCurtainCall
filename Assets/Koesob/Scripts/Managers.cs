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
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    #region Managers
    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }
    #endregion

    private void Awake()
    {

    }

    private void Init()
    {

    }

    private void Clear()
    {

    }
}
