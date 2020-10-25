using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimationEvent : MonoBehaviour
{
    public void Win()
    {
        FindObjectOfType<MiniGameWon>().Win();
    }
}
