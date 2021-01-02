using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    Rigidbody2D asteroidRigidBody;
    Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start(){
        asteroidRigidBody = gameObject.AddComponent<Rigidbody2D>();
        asteroidRigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update(){
        ObjectMovement();
    }

    private void SetObjectMovement(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        asteroidRigidBody.AddForce(movement * 2);
    }

    private void ObjectMovement(){
         if(Input.GetKeyDown(KeyCode.LeftControl)){
            asteroidRigidBody.gravityScale = 1;
        } else if(Input.GetKeyDown(KeyCode.A)){
            transform.Translate(-0.1f, 0f, 0f);  
        } else if(Input.GetKeyDown(KeyCode.D)){
            transform.Translate(0.1f, 0f, 0f);  
        } else if(Input.GetKeyDown(KeyCode.W)){
            transform.Translate(0.0f, 0.1f, 0f);  
        } else if(Input.GetKeyDown(KeyCode.S)){
           transform.Translate(0.0f, -0.1f, 0f);  
        } else if(Input.GetKeyDown(KeyCode.UpArrow)){
            SetObjectMovement();
        } else if(Input.GetKeyDown(KeyCode.DownArrow)){
            SetObjectMovement();;
        } else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            SetObjectMovement();
        } else if(Input.GetKeyDown(KeyCode.RightArrow)){
            SetObjectMovement();
        } else if(Input.GetKeyDown(KeyCode.Space)){
            transform.localScale += new Vector3(1, 1, 0);
        } else if(Input.GetKeyDown(KeyCode.Escape)){
           Destroy(gameObject);
        }
    }
}
