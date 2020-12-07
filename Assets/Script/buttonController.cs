using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour {
    
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite perfectImage;
    public Sprite pressedImage;
    public KeyCode KeyToPress;
    public GameObject Great;
    public GameObject Perfect;

    void Start(){
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyToPress)){
            theSR.sprite = pressedImage;
        }
        if(Input.GetKeyUp(KeyToPress)){
            theSR.sprite = defaultImage;
        }
    }
}
