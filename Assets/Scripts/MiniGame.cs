using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGame : MonoBehaviour
{
    public bool changeScene;
    public int sceneIndex;
    
    public bool runsUnityEvent;
    public UnityEvent runUnityEvent;
    
    public void Run()
    {
        if (changeScene)
        {
            SceneLoader.Instance.LoadScene(sceneIndex);
        }
        else if (runsUnityEvent)
        {
            RunEvent();
        }
    }

    public void RunEvent()
    {
        runUnityEvent.Invoke();
    }
}
