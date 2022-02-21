using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //// Events==============================//
    
    //public static event EventHandler AddTimeEvent;
    public event EventHandler OnCollectEvent;

    ////=====================================//
    
    private static EventManager instance;
    public static EventManager EManager
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No Instance Found : Event MAnager");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void TriggerOnCollectEvent()
    {
        OnCollectEvent?.Invoke(this, EventArgs.Empty);
    }
}
