using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager Game;
    [SerializeField] GameObject taskPrefab;

    public void Init()
    {
        Game = Managers.Game;
    }

    
}