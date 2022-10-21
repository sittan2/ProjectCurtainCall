using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public GameObject curtain;

    public void Init()
    {
        Debug.Log("GameManager Init");

        bgmPlayer.Play();
        Win();
        
    }

    private void Win()
    {
        CloseCurtain();
    }

    private void Lose()
    {
        CloseCurtain();
    }

    private void CloseCurtain()
    {
        curtain.transform.position = new Vector3(-6, 1, -8);

        StartCoroutine(MoveToPosition(curtain.transform, new Vector3(0, 1, -8), 5f));
    }

    private IEnumerator MoveToPosition(Transform _from, Vector3 _to, float _timeToMove)
    {
        var from = transform.position;
        var time = 0f;

        Debug.Log("Hello");

        while(time < 1)
        {
            time += Time.deltaTime / _timeToMove;
            _from.position = Vector3.Lerp(from, _to, time);
            yield return null;
        }
    }
}
