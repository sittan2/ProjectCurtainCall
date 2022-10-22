﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICameraView : MonoBehaviour
{
    [SerializeField] Image ImageOnAir;

    public void OnAir()
    {
        ImageOnAir.gameObject.SetActive(true);
    }

    public void OffAir()
    {
        ImageOnAir.gameObject.SetActive(false);
    }

    public Texture GetTexture()
    {
        return GetComponent<RawImage>().texture;
    }

    internal void SetData(PropCamera prop)
    {
        GetComponent<RawImage>().texture = prop.GetComponent<Camera>().targetTexture;
    }
}