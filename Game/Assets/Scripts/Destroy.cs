﻿using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time;

    private void Start ()
    {
        Destroy (gameObject, time);
    } 
}
