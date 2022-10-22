using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtendSceneManager : MonoBehaviour
{
    public void StartMainScene()
    {
        Debug.Log("Main Scene으로 전환합니다.");

        SceneManager.LoadScene("TestScene");
    }
}
