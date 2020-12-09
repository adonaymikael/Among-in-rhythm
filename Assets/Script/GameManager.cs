using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    private GameObject[] NoteHolder;
    public verifyAnimation verifyScorePerHitAnimation;
    public verifyAnimation verifyHandAnimation;
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
    private Text textEnterGame;
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
    public double scorePerHit;
    public double myScore =0;
    public Text scorePerText;
    private float pulse;
    public int hp = 4;
    public Animator playerAnimation;
    public GameObject playerComponents;
    public GameObject hand;
    private Animator handAnimation;
    private Transform handTrasform;

    private int HandRoationZ;

    void Start(){
        instance = this;
        textEnterGame = EnterGame.GetComponent<Text>();
        PunctuationSprite = Punctuation.GetComponent<Image>();
        NoteHolder = GameObject.FindGameObjectsWithTag("Note");
        sizeNoteHolder = NoteHolder.Length;
        scorePerHit = maxScore/(float)sizeNoteHolder;
        playerComponents = GameObject.FindGameObjectsWithTag("Player")[0];
        playerAnimation = playerComponents.GetComponent<Animator>();
        handAnimation = hand.GetComponent<Animator>();
        handTrasform = hand.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        musicTime = theMusic.time;
        if(verifyScorePerHitAnimation.endAnimation_scorePerHit){
            scorePerText.text = "";
            verifyScorePerHitAnimation.endAnimation_scorePerHit = false;
            PunctuationSprite.enabled = false;
        }

        if(verifyHandAnimation.endAnimation_handFire){
        handTrasform.Rotate(0 , 0, -HandRoationZ, Space.Self);
        verifyHandAnimation.endAnimation_handFire = false;
        hand.SetActive(false);
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

        if(theMusic.isPlaying){
            pulseText.text = "Pulses: "+pulse; 
        }else{
            pulseText.text = "Pulses: 0";
            StartCoroutine(finished());
        }
        
        musictimeText.text = "Music Timer: "+(int)musicTime+"s";
        //Debug.Log(musicTime);
        }
    }

    public void NoteHit(int NoteScore,int ButtonY){
        Debug.Log("Hit On time");

        switch (NoteScore){
            case 1:
            FireNote(perfectSprite,1,ButtonY); //1 = 100%; da nota
            break;

            case 2:
            FireNote(greatSprite,0.75f,ButtonY); //0.75 = 75% da nota
            break;

            case 3:
            FireNote(goodSprite,0.50f,ButtonY); //0.50 = 50% da nota
            break;
        }
        //Debug.Log(NoteScore);
        if(scorePerText.GetComponent<Animation>().isPlaying){
            scorePerText.GetComponent<Animation>().Stop(); 
            scorePerText.GetComponent<Animation>().Play(); 
        }
    }
    public void FireNote(Sprite noteSprite, float PorcentPerHit, int HandRoationZ){
        this.HandRoationZ = HandRoationZ;
        playerAnimation.SetTrigger("fire_1");
        hand.SetActive(true);
        handAnimation.SetTrigger("fire");
        handTrasform.Rotate(0 , 0, HandRoationZ, Space.World);

        Punctuation.enabled = true;
        PunctuationSprite.sprite = noteSprite;
        myScore +=scorePerHit*PorcentPerHit;
        scoreText.text = ((int)myScore).ToString();
        scorePerText.text = "+"+(int)(scorePerHit*PorcentPerHit);
        scorePerText.GetComponent<Animation>().Play();
        
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
        
    }

    IEnumerator finished(){
        yield return new WaitForSeconds(1);
        textEnterGame.text = "Parabens!!!";
        EnterGame.SetActive(true);
    }


}

