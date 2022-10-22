using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtendSceneManager : MonoBehaviour
{
    private string result;
    public void Init()
    {
        Debug.Log("Scene Manager Init");
    }
    public void StartMainScene()
    {
        Debug.Log("Main Scene으로 전환합니다.");

        SceneManager.LoadScene("TestScene");
    }

    public void StartEndScene(bool _isWin)
    {
        if(_isWin)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("LoseScene");
        }
        
    }
}
