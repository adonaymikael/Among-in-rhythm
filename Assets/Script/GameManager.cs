using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject EnterGame;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    public GameObject heart_4;
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
    public int hp = 4;
    public Animator playerAnimation;
    public GameObject playerComponents;

    void Start(){
        instance = this;
        PunctuationSprite = Punctuation.GetComponent<Image>();
        NoteHolder = GameObject.FindGameObjectsWithTag("Note");
        sizeNoteHolder = NoteHolder.Length;
        scorePerHit = maxScore/(float)sizeNoteHolder;
        playerComponents = GameObject.FindGameObjectsWithTag("Player")[0];
        playerAnimation = playerComponents.GetComponent<Animator>();
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

                EnterGame.SetActive(false);
                
                theMusic.Play();
            }
        }else{
        pulse += theBS.beatTempo * Time.deltaTime;
        pulseText.text = "Pulses: "+pulse; 
        musictimeText.text = "Music Timer: "+(int)musicTime+"s";
        //Debug.Log(musicTime);
        }
    }

    public void NoteHit(int NoteScore){
        Debug.Log("Hit On time");

        playerAnimation.SetTrigger("fire_1");
        

        if(NoteScore == 1){
        Punctuation.enabled = true;
        PunctuationSprite.sprite = perfectSprite;
        myScore +=scorePerHit; //100% da nota
        scoreText.text = ((int)myScore).ToString();
        scorePerText.text = "+"+((int)scorePerHit+1);
        scorePerText.GetComponent<Animation>().Play();    
        }

        if(NoteScore == 2){
        Punctuation.enabled = true;
        PunctuationSprite.sprite = greatSprite;
        myScore +=scorePerHit*0.75; //75% da nota
        scoreText.text = ((int)myScore).ToString();
        scorePerText.text = "+"+(int)((scorePerHit*0.75)+1);
        scorePerText.GetComponent<Animation>().Play();
        }

        if(NoteScore == 3){
        Punctuation.enabled = true;
        PunctuationSprite.sprite = goodSprite;
        myScore +=scorePerHit*0.50; //50% da nota
        scoreText.text = ((int)myScore).ToString();
        scorePerText.text = "+"+(int)((scorePerHit*0.50)+1);
        scorePerText.GetComponent<Animation>().Play();
        }

        //Debug.Log(NoteScore);
        if(scorePerText.GetComponent<Animation>().isPlaying){
            scorePerText.GetComponent<Animation>().Stop(); 
            scorePerText.GetComponent<Animation>().Play(); 
        }
    }

    public void NoteMissed(){
        Debug.Log("Missed Note");
        Punctuation.enabled = true;
        PunctuationSprite.sprite = badSprite;
        hp -= 1;

        if(hp <= 0){
            SceneManager.LoadScene("GameOver");
        } else if(hp == 3) {
            heart_1.SetActive(false);
        } else if(hp == 2) {
            heart_2.SetActive(false);
        } else if(hp == 1) {
            heart_3.SetActive(false);
        }
    }

    public void endAnimation(){
        Debug.Log("acabou2");
    }


}

