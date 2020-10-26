using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader _instance;
    public static SceneLoader Instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            //Debug.Log("Duplicate Deleted:: SceneLoader - There can only be one. Ignore this if the same scene was loaded.");
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
