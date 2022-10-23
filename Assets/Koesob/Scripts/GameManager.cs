using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource bgmPlayer;
    public GameObject curtain;
    public int viewer;
    public int combo = 0;
    public Prop selectedProp;
    public float endTime;

    private void Update()
    {
        float time = bgmPlayer.time;

        if(time >= endTime)
        {
            Managers.Scene.StartEndScene(true);
        }
    }

    public void Init()
    {
        Debug.Log("GameManager Init");

        bgmPlayer.Play();

        curtain.SetActive(false);

        endTime = bgmPlayer.maxDistance;
    }

    public void IncreaseViewer(int _amount, bool isPerfect = false)
    {
        viewer += _amount;
        viewer += combo;

        if (isPerfect)
            combo++;
        else
            combo = 0;
    }

    public void DecreaseVeiwer(int _amount)
    {
        var tempViewer = viewer - _amount;
        combo = 0;

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

    private void Win()
    {
        bgmPlayer.Stop();

        CloseCurtain();

        StartCoroutine(DelayClear(true));
    }

    private void Lose()
    {
        bgmPlayer.Stop();

        CloseCurtain();

        StartCoroutine(DelayClear(false));
    }

    private void CloseCurtain()
    {
        curtain.transform.position = new Vector3(-15, 2.5f, 0f);
        curtain.SetActive(true);

        StartCoroutine(MoveToPosition(curtain.transform, new Vector3(0f, 2.5f, 0f), 1f));
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

    private IEnumerator DelayClear(bool _isWin)
    {
        yield return new WaitForSeconds(2f);

        Managers.Scene.StartEndScene(_isWin);
    }

    public void SetSelectedProp(Prop _prop)
    {
        var preProp = selectedProp;

        if(preProp != _prop)
        {
            selectedProp = _prop;

            Managers.UI.RefreshCommandUI(selectedProp);
        }
    }

    public void CancleProp()
    {
        SetSelectedProp(null);
    }
}
