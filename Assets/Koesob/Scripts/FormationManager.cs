using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public List<GameObject> actors;
    [SerializeField]public List<Tuple<float, Vector3>> formations;
}
