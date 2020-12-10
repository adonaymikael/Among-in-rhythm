using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{
    public GameObject button;
    public bool canBePressed;
    private KeyCode keyButton;
    private buttonController buttonController;
    private Collider2D GreatTrigger;
    private Collider2D PerfectTrigger;
    public int NoteScore;
    public int ButtonY;
    void Start()
    {
        // NoteScore = 3: Good
        // NoteScore = 2: Great
        // NoteScore = 1: Perfect
        buttonController = button.GetComponent<buttonController>();
        GreatTrigger = buttonController.Great.GetComponent<Collider2D>();
        PerfectTrigger = buttonController.Perfect.GetComponent<Collider2D>();
        keyButton = buttonController.KeyToPress;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyButton)){
            if(canBePressed){
                gameObject.SetActive(false);
                GameManager.instance.NoteHit(NoteScore,ButtonY);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Button"){
        var ButtonName = other.gameObject.name;
        switch (ButtonName) {
            case "button_1":
            //Debug.Log("Em cima");
            ButtonY = 50;
            break;

            case "button_2":
            //Debug.Log("Meio");
            ButtonY = 30;
            break;

            case "button_3":
            //Debug.Log("Baixo");
            ButtonY = 0;
            break;
        }

            canBePressed = true;
            NoteScore = 3;
            //Debug.Log("Good");
        }
        if(other.tag == "Great"){
            NoteScore = 2;
                //Debug.Log("Great");
        }
        if(other.tag == "Perfect"){
            NoteScore = 1;
                //Debug.Log("Perfect");
        }
    }

        private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Button"){
            canBePressed = false;
            if(gameObject.activeSelf){
                gameObject.SetActive(false);
                GameManager.instance.NoteMissed();
            }
        }
    }
}
