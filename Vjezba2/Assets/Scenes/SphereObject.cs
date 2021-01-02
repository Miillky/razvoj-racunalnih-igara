using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObject : MonoBehaviour {
    // Start is called before the first frame update
    void Start(){
        Debug.Log("Pozdrav is start");
    }

    // Update is called once per frame
    void Update(){
        Debug.Log("Pozdrav iz update");
        Debug.Log("Ime: " + this.gameObject.name + " Tag: " + this.gameObject.tag + " Transform position: " + this.gameObject.transform.position);
    }
}
