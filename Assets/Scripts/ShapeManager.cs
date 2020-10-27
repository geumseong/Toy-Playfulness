using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    public GameObject combination1;
    public GameObject combination2;
    public GameObject combination3;

    // Start is called before the first frame update
    void Start()
    {
        switch(Random.Range(0, 3)) {
            case 0:
                combination1.SetActive(true);
                combination2.SetActive(false);
                combination3.SetActive(false);
                break;
            case 1:
                combination1.SetActive(false);
                combination2.SetActive(true);
                combination3.SetActive(false); 
                break;
            case 2:
                combination1.SetActive(false);
                combination2.SetActive(false);
                combination3.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
