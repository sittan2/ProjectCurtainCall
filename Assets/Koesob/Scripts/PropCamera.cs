using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCamera : Prop
{
    public List<Vector3> rotations;
    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        transform.LookAt(new Vector3(0, 2,8));
    }

    public void ZoomIn()
    {
        var view = camera.fieldOfView;

        if(view - 10 <= 30)
        {
            view = 30;
        }
        else
        {
            view -= 10;
        }

        camera.fieldOfView = view;

        StartCoroutine(AdjustZoom(camera, view, 1f));

        string command = type + "_" + number + "_" + Define.ActionType.Zoom + "_" + "0";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.Lens);
    }

    public void ZoomOut()
    {
        var view = camera.fieldOfView;

        if (view + 10 >= 60)
        {
            view = 60;
        }
        else
        {
            view += 10;
        }

        camera.fieldOfView = view;

        string command = type + "_" + number + "_" + Define.ActionType.Zoom + "_" + "1";

        StartCoroutine(AdjustZoom(camera, view, 1f));
        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.Lens);
    }

    public void MoveToOne()
    {
        StartCoroutine(MoveToPosition(transform, positions[0], 1f));

        string command = type + "_" + number + "_" + Define.ActionType.MoveTo + "_" + "1";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.Lens);
    }

    public void MoveToTwo()
    {
        StartCoroutine(MoveToPosition(transform, positions[1], 1f));

        string command = type + "_" + number + "_" + Define.ActionType.MoveTo + "_" + "2";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.Lens);
    }

    public void MoveToThree()
    {
        StartCoroutine(MoveToPosition(transform, positions[2], 1f));

        string command = type + "_" + number + "_" + Define.ActionType.MoveTo + "_" + "3";

        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.Lens);
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

    private IEnumerator AdjustZoom(Camera _from, float _to, float _timeToAdjust)
    {
        var from = _from.fieldOfView;
        var time = 0f;

        while (time < 1)
        {
            time += Time.deltaTime / _timeToAdjust;

            _from.fieldOfView = Mathf.Lerp(from, _to, time);
            yield return null;
        }
    }

    public void On()
    {
        string command = type + "_" + number + "_" + Define.ActionType.OnOff + "_" + "1";

        Managers.UI.OnCamera(number);
        Managers.Task.DoCommand(command);
        Managers.Sound.Play(Define.SoundType.CameraOn);
    }
}
