using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtendSceneManager : MonoBehaviour
{
    public void StartMainScene()
    {
        Debug.Log("Main Scene���� ��ȯ�մϴ�.");

        SceneManager.LoadScene("TestScene");
    }
}
