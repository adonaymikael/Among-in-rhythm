using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    public float SpawnSpeed = 35;
    public bool Destroyed = false;
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        transform.position -= new Vector3(SpawnSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other){
        StartCoroutine(Destroy());
        //Debug.Log(other);
    }

    IEnumerator Destroy(){
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        Destroyed = true;
    }
}
