using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector2 movement = new Vector2();
    private Rigidbody2D rigidBody;
    [SerializeField]
    private GameObject prefab;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.LeftControl)){
            rigidBody.gravityScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.S)){
            transform.localScale += new Vector3(1, 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            CreatePrefabObject();
        }

        MovementHandler();
    }

    private void MovementHandler(){
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        rigidBody.velocity = movement * 3;
    }

    private void CreatePrefabObject(){
        Vector3 prefabPosition = new Vector3();
        prefabPosition.x = this.gameObject.transform.position.x + 2;
        prefabPosition.y = this.gameObject.transform.position.y + 2;

        if(prefab != null){
            Instantiate(prefab, prefabPosition, Quaternion.identity);
        }
    }
}
