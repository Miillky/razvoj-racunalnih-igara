using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereJump : MonoBehaviour {
    Rigidbody body;
    // Start is called before the first frame update
    void Start(){
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 force = new Vector3(0, 200, 0);
            body.AddForce(force);
            Debug.Log("Skok");
        }
    }
}
