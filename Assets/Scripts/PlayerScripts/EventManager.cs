using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void  AnimLoader();

    public static event AnimLoader Animate;

    public static void NotifyAnimation()
    {
        Animate?.Invoke();
    }
}