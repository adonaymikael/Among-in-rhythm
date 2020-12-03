using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{
    public GameObject button;
    public bool canBePressed;
    private KeyCode keyButton;
    private buttonController buttonController;
    void Start()
    {
        buttonController = button.GetComponent<buttonController>();
        keyButton = buttonController.KeyToPress;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyButton)){
            if(canBePressed){
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Button"){
            canBePressed = true;
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Button"){
            canBePressed = false;
            if(gameObject.activeSelf){
                GameManager.instance.NoteMissed();
            }
        }
    }
}
