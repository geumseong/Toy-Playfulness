using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameWon : MonoBehaviour
{
    public GameObject winUI;
    public GameObject looseUI;
    public Animator animator;

    public AudioClip looseClip;
    private AudioSource audioSource;

    private void Start()
    {
        winUI.SetActive(false);
        looseUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLooseSound()
    {
        audioSource.clip = looseClip;
        audioSource.Play();
    }

    public void Loose()
    {
        StartCoroutine(ReturnToMainLose());
    }

    private IEnumerator ReturnToMainLose()
    {
        animator.SetTrigger("Loose");
        yield return null;
        looseUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneLoader.Instance.ReloadScene();
    }

    public void Win()
    {
        StartCoroutine(ReturnToMainWin());
    }

    private IEnumerator ReturnToMainWin()
    {
        animator.SetTrigger("Win");
        yield return null;
        winUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneLoader.Instance.LoadScene(2);
    }
}
