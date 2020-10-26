using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationManager : MonoBehaviour
{
    public Animator carAnimator;

    public bool carFueled;
    private bool _hatchClosed;
    public bool HatchClosed
    {
        get { return _hatchClosed; }
        set
        {
            _hatchClosed = value;
            WinGame();
        }
    }

    public void WinGame()
    {
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        if (HatchClosed && carFueled)
        {
            yield return new WaitForSeconds(0.5f);
            carAnimator.SetTrigger("DriveOff");
            yield return new WaitForSeconds(2f);
            FindObjectOfType<MiniGameWon>().Win();
        }
    }
}
