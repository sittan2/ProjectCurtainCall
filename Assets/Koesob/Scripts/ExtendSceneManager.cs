using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtendSceneManager : MonoBehaviour
{
    public void Init()
    {
        Debug.Log("Scene Manager Init");
    }
    public void StartMainScene()
    {
        Debug.Log("Main Scene���� ��ȯ�մϴ�.");

        SceneManager.LoadScene("TestScene");
    }

    public void StartEndScene(bool _isWin)
    {
        SceneManager.LoadScene("EndScene");

        TextMeshProUGUI resultText = GameObject.Find("ResultText").GetComponent<TextMeshProUGUI>();

        if (_isWin)
        {
            resultText.text = "�����߽��ϴ�!";
        }
        else
        {
            resultText.text = "�����߽��ϴ�!";
        }
    }

    public void OnSceneLoaded
}
