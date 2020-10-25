using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public int launchForce;
    float holdDownStartTime;
    Vector2 direction;

    public Image powerBarMask;
    public GameObject powerBarObj;
    public float powerChangeSpeed = 1f;
    bool updatingPower;
    bool increasingPower;
    float maxPowerValue = 100;
    float currentPowerValue;
    float fillValue;
    
    void Start()
    {
        currentPowerValue = 0;
        increasingPower = true;
        updatingPower = false;
    }

    void Update()
    {
        Vector2 rotationPivot = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - rotationPivot;
        transform.right = direction;

        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Button Down");
            if(updatingPower == false) {
                updatingPower = true;
                powerBarObj.SetActive(true);
                StartCoroutine(UpdatePowerBar());
                Debug.Log("staredCoroutine");
            }
        }

        if(Input.GetMouseButtonUp(0)){
            Debug.Log("Button Up");
        }
    }

    IEnumerator UpdatePowerBar()
    {
        while (updatingPower == true)
        {
            if (!increasingPower)
            {
                currentPowerValue -= powerChangeSpeed;
                if (currentPowerValue <= 0)
                {
                    increasingPower = true;
                }
            }
            if (increasingPower)
            {
                currentPowerValue += powerChangeSpeed;
                if (currentPowerValue >= maxPowerValue)
                {
                    increasingPower = false;
                }
            }
            
            fillValue = currentPowerValue / maxPowerValue;
            powerBarMask.fillAmount = fillValue;
            yield return new WaitForSeconds(0.01f);

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("coroutine mouse up");
                LaunchArrow(fillValue);
                currentPowerValue = 0;
                increasingPower = true;
                updatingPower = false;
                StartCoroutine(TurnOffPowerBar());
            }
        }
        yield return null;
    }
    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(0.01f);
        powerBarObj.SetActive(false);
    }

    public void LaunchArrow(float force){
        GameObject newArrow = Instantiate(arrow);
        newArrow.transform.position = transform.position;
        newArrow.GetComponent<Rigidbody2D>().AddForce(direction * launchForce * force);
    }
}
