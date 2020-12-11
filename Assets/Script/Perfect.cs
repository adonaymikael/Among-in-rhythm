using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfect : MonoBehaviour {
    public Sprite PerfectTime;
    private SpriteRenderer ObjSpriteRender;
    public static Sprite ObjSprite;

    // Start is called before the first frame update
    void Start()
    {
        ObjSpriteRender = GetComponentInParent<SpriteRenderer>();
        ObjSprite = ObjSpriteRender.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ObjSpriteRender.sprite = PerfectTime;
    }
    private void OnTriggerExit2D(Collider2D other) {
        ObjSpriteRender.sprite = ObjSprite;
    }
}
