using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    private float movementSpeed = 3.0f;
    private Vector2 movement = new Vector2();
    private Rigidbody2D rigidBody;

    [SerializeField]
    private GameObject prefab;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update(){
        MovementHandler();
    }
    private void MovementHandler(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log("X: " + movement.x + " " + "Y: " + movement.y);
        movement.Normalize();
        rigidBody.velocity = movement * movementSpeed;
    }
}
