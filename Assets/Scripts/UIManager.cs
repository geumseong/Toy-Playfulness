using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }

    public GameObject interactUI;

    private void Start()
    {
        _instance = this;
        HideInteractable();
    }

    public void DisplayInteractable()
    {
        interactUI.SetActive(true);
        //Debug.Log("Display");
    }

    public void HideInteractable()
    {
        interactUI.SetActive(false);
        //Debug.Log("Hide");
    }
}
