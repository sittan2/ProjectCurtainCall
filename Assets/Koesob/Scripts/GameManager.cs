using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public GameObject curtain;
    public int viewer;
    public Prop selectedProp;

    public void Init()
    {
        Debug.Log("GameManager Init");

        bgmPlayer.Play();
    }

    public void IncreaseViewer(int _amount)
    {
        viewer += _amount;
    }

    public void DecreaseVeiwer(int _amount)
    {
        var tempViewer = viewer - _amount;

        if(tempViewer <= 0)
        {
            viewer = 0;
            Lose();
        }
        else
        {
            viewer = tempViewer;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Win();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            Lose();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DecreaseVeiwer(50);
        }
    }

    private void Win()
    {
        CloseCurtain();
    }

    private void Lose()
    {
        bgmPlayer.Stop();

        CloseCurtain();
    }

    private void CloseCurtain()
    {
        curtain.transform.position = new Vector3(-6, 1, -8);

        StartCoroutine(MoveToPosition(curtain.transform, new Vector3(0, 1, -8), 1f));
    }

    private IEnumerator MoveToPosition(Transform _from, Vector3 _to, float _timeToMove)
    {
        var from = _from.position;
        var time = 0f;

        while (time < 1)
        {
            time += Time.deltaTime / _timeToMove;

            _from.position = Vector3.Lerp(from, _to, time);
            yield return null;
        }
    }

    public void SetSelectedProp(Prop _prop)
    {
        selectedProp = _prop;
    }
}
