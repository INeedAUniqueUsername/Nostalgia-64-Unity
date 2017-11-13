using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHit : MonoBehaviour, IHitEffect {
    public Sprite effect;
    public float lifetime;
    public void CreateEffect(Vector3 position) {
        print("Simple Hit Effect created");
        GameObject result = new GameObject();
        result.SetActive(true);
        result.transform.position = position;
        result.AddComponent<SpriteRenderer>().sprite = effect;
        SpriteFade fade = result.AddComponent<SpriteFade>();
        fade.lifespan = lifetime;
        fade.SetLifeLeft(lifetime);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
