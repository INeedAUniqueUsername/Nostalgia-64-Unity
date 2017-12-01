using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexplosion : MonoBehaviour {
	public Transform hex;
    public float width = 0.5f;
    public float height = 0.6f;
	public float expandInterval;
	private float nextExpandTime;
	List<Transform> tiles;
	void Start() {
		tiles = new List<Transform>();
		tiles.Add(CreateTile(true, true, true, true, true, true));
	}
	void Update() {
		nextExpandTime--;
		if(nextExpandTime < 1) {
			nextExpandTime = expandInterval;
			List<Transform> nextTiles = new List<Transform>();
			foreach(Transform tile in tiles) {
				HexplosionTile component = tile.GetComponent<HexplosionTile>();
				Vector2 pos = tile.transform.localPosition + new Vector3(-width/2, height);
				if(component.upLeft/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(true, true, false, true, false, false);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
				pos = tile.transform.localPosition + new Vector3(0, height);
				if(component.up/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(true, true, true, false, false, false);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
				pos = tile.transform.localPosition + new Vector3(width/2, height);
				if(component.upRight/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(false, true, true, false, false, true);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
				pos = tile.transform.localPosition + new Vector3(-width/2, -height);
				if(component.downLeft/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(true, false, false, true, true, false);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
				pos = tile.transform.localPosition + new Vector3(0, -height);
				if(component.down/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(false, false, false, true, true, true);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
				pos = tile.transform.localPosition + new Vector3(width/2, -height);
				if(component.downRight/* && CanCreateTile(pos)*/) {
					Transform t = CreateTile(false, false, true, false, true, true);
					nextTiles.Add(t);
					t.localPosition = pos;
				}
			}
			tiles = nextTiles;
		}
	}
	public bool CanCreateTile(Vector2 pos) {
		Collider2D[] colliders = Physics2D.OverlapPointAll(pos);
		foreach(Collider2D collider in colliders) {
			if(collider.gameObject.transform.parent == gameObject) {
				return false;
			}
		}
		return true;
	}
	Transform CreateTile(bool upLeft, bool up, bool upRight, bool downLeft, bool down, bool downRight) {
		Transform result = Instantiate(hex, gameObject.transform);
		result.gameObject.SetActive(true);
		HexplosionTile h = result.gameObject.AddComponent<HexplosionTile>();
		h.upLeft = upLeft;
		h.up = up;
		h.upRight = upRight;
		h.downLeft = downLeft;
		h.down = down;
		h.downRight = downRight;
		return result;
	}
}
public class HexplosionTile : MonoBehaviour {
	public bool upLeft,		up,		upRight,
				downLeft,	down,	downRight;
	void OnTriggerEnter2D(Collider2D other) {
		print("Hexplosion Tile collision");
		if(other.transform.parent = transform.parent) {
			Destroy(gameObject);
		}
	}
	
}