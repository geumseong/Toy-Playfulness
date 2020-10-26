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
    public GameObject pauseUI;

    public bool paused;

    private void Start()
    {
        _instance = this;
        paused = false;
        HideInteractable();
        HidePauseUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                HidePauseUI();
            }
            else
            {
                DisplayPauseUI();
            }
        }
    }

    public void DisplayInteractable()
    {
        interactUI.SetActive(true);
    }

    public void HideInteractable()
    {
        interactUI.SetActive(false);
    }

    public void DisplayPauseUI()
    {
        pauseUI.SetActive(true);
        paused = true;
    }

    public void HidePauseUI()
    {
        pauseUI.SetActive(false);
        paused = false;
    }
}
