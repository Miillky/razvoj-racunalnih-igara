using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float movementSpeed = 3.0f;
    private Vector2 movement = new Vector2();
    private Rigidbody2D rigidBody;

    private Animator animator;
    private string animationState = "AnimationState";

    enum AnimStates {
        idle = 0,
        walk_down = 1,
        walk_right = 2,
        walk_up = 3,
        walk_left = 4,
    }

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update(){
        MovementHandler();
        AnimationHandler();
    }
    private void MovementHandler(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + movement.x + " " + "Y: " + movement.y);
        movement.Normalize();
        rigidBody.velocity = movement * movementSpeed;
    }

    private void AnimationHandler(){
        if(movement.x > 0){
            animator.SetInteger(animationState, (int)AnimStates.walk_right);
        } else if(movement.x < 0){
            animator.SetInteger(animationState, (int)AnimStates.walk_left);
        } else if(movement.y > 0){
            animator.SetInteger(animationState, (int)AnimStates.walk_up);
        } else if(movement.y < 0){
            animator.SetInteger(animationState, (int)AnimStates.walk_down);
        } else {
            animator.SetInteger(animationState, (int)AnimStates.idle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.name);
        Destroy(collider.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.tag == "Door"){
            Debug.Log(collider.gameObject.name + " OnCollisionEnter2D");
        }
    }

    private void OnCollisionStay2D(Collision2D collider) {
        if(collider.gameObject.tag == "Door"){
            Debug.Log(collider.gameObject.name + " OnCollisionStay2D");
            GameManager.sharedInstance.LoadLevelOneHouse();
        }
    }

    private void OnCollisionExit2D(Collision2D collider) {
        if(collider.gameObject.tag == "Door"){
            Debug.Log(collider.gameObject.name + " OnCollisionExit2D");
        }
    }
}
