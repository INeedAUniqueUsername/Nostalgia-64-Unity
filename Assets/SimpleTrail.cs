using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrail : MonoBehaviour {
    public float interval;
    public float lifetime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        interval--;
        if(!(interval > 0)) {
            GameObject result = new GameObject();
            result.transform.position = transform.position;
            result.transform.eulerAngles = transform.eulerAngles;
            result.SetActive(true);
            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
            SpriteFade fade = result.AddComponent<SpriteFade>();
            fade.lifespan = lifetime;
            fade.SetLifeLeft(lifetime);
        }
	}
}
