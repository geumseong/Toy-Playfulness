using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameWon : MonoBehaviour
{
    public GameObject winUI;
    public Animator animator;

    private void Start()
    {
        winUI.SetActive(false);
    }

    public void Win()
    {
        StartCoroutine(ReturnToMain());
    }

    private IEnumerator ReturnToMain()
    {
        animator.SetTrigger("Win");
        yield return null;
        winUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneLoader.Instance.LoadScene(2);
    }
}
