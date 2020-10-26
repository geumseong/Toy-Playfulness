using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Bow : MonoBehaviour
{
    public GameObject pullPhase1;
    public GameObject pullPhase3;
    public GameObject pullPhase2;

    public GameObject scoreText;
    
    public GameObject arrow;
    public int launchForce;
    float holdDownStartTime;
    Vector2 direction;

    public Image powerBarMask;
    public GameObject powerBarCanvas;
    public float powerChangeSpeed = 1f;
    bool updatingPower;
    bool increasingPower;
    float maxPowerValue = 100;
    float currentPowerValue;
    float fillValue;

    public int score;
    
    void Start()
    {
        currentPowerValue = -1;
        increasingPower = true;
        updatingPower = false;

        pullPhase1.SetActive(false);
        pullPhase2.SetActive(false);
        pullPhase3.SetActive(false);

        powerBarCanvas.SetActive(false);
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
                powerBarCanvas.SetActive(true);
                StartCoroutine(UpdatePowerBar());
                Debug.Log("staredCoroutine");
            }
        }

        if(Input.GetMouseButtonUp(0)){
            Debug.Log("Button Up");
        }

        if(currentPowerValue == -1) {
            pullPhase1.SetActive(true);
            pullPhase2.SetActive(false);
            pullPhase3.SetActive(false);
        }
        else if(currentPowerValue > 50) {
            pullPhase1.SetActive(false);
            pullPhase2.SetActive(false);
            pullPhase3.SetActive(true);
        }
        else {
            pullPhase1.SetActive(false);
            pullPhase2.SetActive(true);
            pullPhase3.SetActive(false);
        }

        scoreText.GetComponent<Text>().text = "Targets : " + score + " / 3";

        if(score == 3) {
            FindObjectOfType<MiniGameWon>().Win();
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
                currentPowerValue = -1;
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
        powerBarCanvas.SetActive(false);
    }

    public void LaunchArrow(float force){
        GameObject newArrow = Instantiate(arrow);
        newArrow.transform.position = transform.position;
        newArrow.GetComponent<Rigidbody2D>().AddForce(direction * launchForce * force);
    }
}
