using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    public void LoadScene(int index)
    {
        SceneLoader.Instance.LoadScene(index);
    }

    public void ReloadScene()
    {
        SceneLoader.Instance.ReloadScene();
    }

    public void Quit()
    {
        SceneLoader.Instance.Quit();
    }
}
