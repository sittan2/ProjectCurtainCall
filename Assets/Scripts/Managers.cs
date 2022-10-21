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
<<<<<<< HEAD
    private GameManager _game = new GameManager();
    private UIManager _uiManager = new UIManager();
    private DataManager _dataManager = new DataManager();
=======
    [SerializeField] private GameManager _game;
>>>>>>> 5f3ab4507ad0f37627f24950461256f277ed0527
    public static GameManager Game { get { return Instance._game; } }
    public static UIManager UI { get { return Instance._uiManager; } }
    public static DataManager Data { get { return Instance._dataManager; } } 

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

            Game.Init();
            Data.Init();
            UI.Init();
        }
    }

    private void Clear()
    {

    }
}
