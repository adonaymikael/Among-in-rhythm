using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    private GameObject[] NoteHolder;
    public verifyAnimation verifyAnimation;
    public bool startPlaying;
    public BeatScroller theBS;
    public KeyCode KeyToStart;
    public static GameManager instance;
    public int sizeNoteHolder;
    public float musicTime;
    public Text musictimeText;
    public Text pulseText;
    public Text scoreText;
    public Image Punctuation;
    private Image PunctuationSprite;
    public Sprite badSprite;
    public Sprite goodSprite;
    public Sprite greatSprite;
    public Sprite perfectSprite;
    public double maxScore = 999999.9;
    private double scorePerHit;
    public double myScore =0;
    public Text scorePerText;
    private float pulse;

    void Start(){
        instance = this;
        PunctuationSprite = Punctuation.GetComponent<Image>();
        NoteHolder = GameObject.FindGameObjectsWithTag("Note");
        sizeNoteHolder = NoteHolder.Length;
        scorePerHit = maxScore/(float)sizeNoteHolder;
    }

    // Update is called once per frame
    void Update(){
        musicTime = theMusic.time;
        if(verifyAnimation.endAnimation_scorePerHit){
            scorePerText.text = "";
            verifyAnimation.endAnimation_scorePerHit = false;
            PunctuationSprite.enabled = false;
        }

        if(!startPlaying){
            if(Input.GetKeyDown(KeyToStart)){
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }else{
        pulse += theBS.beatTempo * Time.deltaTime;
        pulseText.text = "Pulses: "+pulse; 
        musictimeText.text = "Music Timer: "+(int)musicTime+"s";
        //Debug.Log(musicTime);
        }
    }

    public void NoteHit(){
        Debug.Log("Hit On time");
        Punctuation.enabled = true;
        PunctuationSprite.sprite = perfectSprite;
        myScore +=scorePerHit;
        scoreText.text = ((int)myScore).ToString();
        scorePerText.text = "+"+((int)scorePerHit+1);
        scorePerText.GetComponent<Animation>().Play();
        if(scorePerText.GetComponent<Animation>().isPlaying){
            scorePerText.GetComponent<Animation>().Stop(); 
            scorePerText.GetComponent<Animation>().Play(); 
        }
    }

    public void NoteMissed(){
        Debug.Log("Missed Note");
        Punctuation.enabled = true;
        PunctuationSprite.sprite = badSprite;
    }

    public void endAnimation(){
        Debug.Log("acabou2");
    }


}

