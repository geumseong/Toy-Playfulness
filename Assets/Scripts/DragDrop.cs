using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector2 resetPosition;
    string gameObjectTag;
    bool colliding;
    Vector2 collisionPos;
    int count;

    void Awake(){
        
    }
    void Start(){
        resetPosition = this.transform.position;
        gameObjectTag = gameObject.tag;
    }

    void Update(){
        
        if(moving){
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }

    }

    private void OnMouseDown(){
        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;
            
            moving = true;
        }
    }

    private void OnMouseUp(){
        moving = false;

        if(colliding == true){
            this.transform.position = collisionPos;
            //this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
            Debug.Log("Was Colliding when MouseUp");
            if(gameObjectTag == "Envelop") {
                Debug.Log("Destroy");
                GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
                Destroy(gameObject);
            }
            if(GameObject.Find("WinStateManager") != null){
                if(GameObject.Find("WinStateManager").GetComponent<WinStateManager>().count == 4) {
                    GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
                }
            }
            if(gameObjectTag == "leg") {
                GameObject.Find("WinMinigame").GetComponent<MiniGameWon>().Win();
            }
        }
        else{
            this.transform.position = new Vector2(resetPosition.x, resetPosition.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(gameObjectTag == collision.tag) {
            colliding = true;
            if(GameObject.Find("WinStateManager") != null){
                GameObject.Find("WinStateManager").GetComponent<WinStateManager>().count++;
                Debug.Log(GameObject.Find("WinStateManager").GetComponent<WinStateManager>().count);
            }
            collisionPos = new Vector2(collision.transform.position.x, collision.transform.position.y);
            Debug.Log("newpositionSet");
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(gameObjectTag == collision.tag) {
            colliding = false;
            if(GameObject.Find("WinStateManager") != null){
                GameObject.Find("WinStateManager").GetComponent<WinStateManager>().count--;
                Debug.Log(GameObject.Find("WinStateManager").GetComponent<WinStateManager>().count);
            }
            collisionPos = new Vector2(resetPosition.x, resetPosition.y);
            Debug.Log("newpositionReset");
        }
    }
}