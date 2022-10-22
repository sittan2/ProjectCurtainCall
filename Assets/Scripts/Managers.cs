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
    [SerializeField] private GameManager _game;
    [SerializeField] UIManager _uiManager;
    [SerializeField] TaskManager _taskManager;
    [SerializeField] SoundManager _soundManager;
    private DataManager _dataManager = new DataManager();
    [SerializeField] private ExtendSceneManager _scene;

    public static GameManager Game { get { return instance._game; } }
    public static UIManager UI { get { return instance._uiManager; } }
    public static DataManager Data { get { return instance._dataManager; } } 
    public static TaskManager Task { get { return instance._taskManager; } }
    public static SoundManager Sound { get { return instance._soundManager; } }

    public static ExtendSceneManager Scene { get { return instance._scene; } }

    #endregion

    private void Awake()
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

            Data.Init();
            Game.Init();
            UI.Init();
            Task.Init();
            Scene.Init();
        }
    }

    private void Clear()
    {

    }
}
