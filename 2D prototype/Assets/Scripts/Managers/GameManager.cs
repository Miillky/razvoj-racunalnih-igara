using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager sharedInstance = null;

    void Awake(){
        if(sharedInstance != null && sharedInstance != this){
            Destroy(this.gameObject);
        } else {
            GameObject.DontDestroyOnLoad(gameObject);
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            LoadLevelOne();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        Debug.Log("Scene loaded: " + scene.name);
    }

    public void LoadLevelOne(){
        SceneManager.LoadScene(1);
    }

    public void LoadLevelOneHouse(){
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }
}
