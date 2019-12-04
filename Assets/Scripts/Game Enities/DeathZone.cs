﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public delegate void DeathZoneDelegate();
    public static event DeathZoneDelegate OnFellOutOfMap;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnFellOutOfMap?.Invoke();
        }
    }
}
