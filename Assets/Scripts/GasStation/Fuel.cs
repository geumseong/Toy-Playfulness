using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Animator tankAnimator;
    public Animator carAnimator;
    public Image tank;
    public Color tint;
    public float fillValue = 0.005f;

    public bool wasFull;
    public bool wasMoved;

    private void Start()
    {
        tank.fillAmount = 0;
    }

    private void OnMouseOver()
    {
        tank.color = tint;
    }

    private void OnMouseExit()
    {
        tank.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (tank.fillAmount == 1 && !wasMoved)
        {
            tankAnimator.SetTrigger("FullFuel");
            wasMoved = true;
        }
        else
        {
            StartCoroutine(WhileMouseDown());
        }
    }

    IEnumerator WhileMouseDown()
    {
        if (!wasFull)
        {
            while (Input.GetMouseButton(0))
            {
                tank.fillAmount += fillValue;
                yield return null;
            }

            if (tank.fillAmount == 1)
            {
                wasFull = true;
            }
        }
        else
        {
            while (Input.GetMouseButton(0))
            {
                tank.fillAmount -= fillValue;
                yield return null;
            }

            if (tank.fillAmount == 0)
            {
                tankAnimator.SetTrigger("EmptyFuel");
                yield return new WaitForSeconds(1f);
                carAnimator.SetTrigger("DriveOff");
            }
        }
    }
}
