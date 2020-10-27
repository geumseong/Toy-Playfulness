using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsManager : MonoBehaviour
{
    public GameObject legSlot;
    public GameObject scarSlot;
    public GameObject colliderObj;
    public Sprite[] legSprites;
    public Sprite[] scarSprites;

    // Start is called before the first frame update
    void Start()
    {
        legSlot.GetComponent<SpriteRenderer>().sprite = legSprites[Random.Range(0, 3)];
        int scarIndex = Random.Range(0, 3);
        scarSlot.GetComponent<SpriteRenderer>().sprite = scarSprites[scarIndex];
        switch(scarIndex) {
            case 0:
                colliderObj.transform.localPosition = new Vector2(-7.51f, -3.61f);
                break;
            case 1:
                colliderObj.transform.localPosition = new Vector2(-5.27f, 0.11f);
                break;
            case 2:
                colliderObj.transform.localPosition = new Vector2(-7.25f, -0.48f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
