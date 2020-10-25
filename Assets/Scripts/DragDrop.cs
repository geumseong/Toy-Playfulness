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

    void Awake(){
        
    }
    void Start(){
        resetPosition = this.transform.localPosition;
        gameObjectTag = gameObject.tag;
    }

    void Update(){
        
        if(moving){
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }

    }

    private void OnMouseDown(){
        if (Input.GetMouseButtonDown(0)){
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            
            moving = true;
        }
    }

    private void OnMouseUp(){
        moving = false;

        if(colliding == true){
            this.transform.position = collisionPos;
            //this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
        }
        else{
            this.transform.position = new Vector2(resetPosition.x, resetPosition.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(gameObjectTag == collision.tag) {
            colliding = true;
            collisionPos = new Vector2(collision.transform.localPosition.x, collision.transform.localPosition.y);
            Debug.Log("newpositionSet");
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(gameObjectTag == collision.tag) {
            colliding = false;
            collisionPos = new Vector2(resetPosition.x, resetPosition.y);
            Debug.Log("newpositionReset");
        }
    }
}