using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public GameObject NoteA;
    public GameObject NoteS;
    public GameObject NoteD;
    public GameObject[] Notas;
    private Transform MyPosiiton;
    void Start(){
        MyPosiiton = GetComponent<Transform>();
        //Instantiate(NoteA, MyPosiiton);
    }
    void Update()
    {
        Notas = GameObject.FindGameObjectsWithTag("NoteMenu");
        for (int i = 0; i < Notas.Length; i++){
            //Debug.Log(i);
        }
        if (Notas.Length == 0){
            SpawnReadom();
            
        }

    }

    void SpawnReadom(){
        var x = Random.Range(1, 4);
        switch (x){
            case 1:
                Instantiate(NoteA, MyPosiiton);
                break;

            case 2:
                Instantiate(NoteS, MyPosiiton);
                break;

            case 3:
                Instantiate(NoteD, MyPosiiton);
                break;
        }
    }
}
