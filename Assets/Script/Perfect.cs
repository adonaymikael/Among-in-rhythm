﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfect : MonoBehaviour {
    public GameObject rhythm_0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        rhythm_0.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        rhythm_0.SetActive(false);
    }
}