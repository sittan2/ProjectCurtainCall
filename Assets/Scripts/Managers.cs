using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance { get { return instance; } }

    #region Managers
    private GameManager _game = new GameManager();
    public static GameManager Game { get { return Instance._game; } }
    #endregion

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();

            //Data.Init();
            Game.Init();
        }
    }

    private void Clear()
    {

    }
}
