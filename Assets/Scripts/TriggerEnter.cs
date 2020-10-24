using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.DisplayInteractable();
            CarController.Instance.SetOnTrigger(true, GetComponent<MiniGame>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.HideInteractable();
            CarController.Instance.SetOnTrigger(false, null);
        }
    }
}
