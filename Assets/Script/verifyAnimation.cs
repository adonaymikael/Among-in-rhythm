﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verifyAnimation : MonoBehaviour
{
    public bool endAnimation_scorePerHit = false;
    public bool endAnimation_handFire = false;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void endAnimation(AnimationClip anim){
        //Debug.Log(anim.name);
        
        if(anim.name == "scorePerHit2"){
            endAnimation_scorePerHit = true;
        }

        if(anim.name == "hand_fire"){
            endAnimation_handFire = true;
        }
        
    }
}
