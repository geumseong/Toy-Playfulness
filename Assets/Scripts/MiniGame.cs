using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public bool changeScene;
    public int sceneIndex;
    
    public bool changesSprite;
    public Sprite changeToSprite;

    public bool callsMethod;
    public int methodValue;
    
    public void Run()
    {
        if (changeScene)
        {
            SceneLoader.Instance.LoadScene(sceneIndex);
        }
        else if (changesSprite)
        {
            CarController.Instance.ChangeSprite(changeToSprite);
        }
        else if (callsMethod)
        {
            GenericMethod(methodValue);
        }
    }

    public void GenericMethod(int methodValue)
    {
        switch (methodValue)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
