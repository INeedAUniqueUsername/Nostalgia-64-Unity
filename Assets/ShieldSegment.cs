using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSegment : MonoBehaviour, IDamageable {
	public double segmentMaxHP;
	public double segmentHP;
	public double segmentRegenRate;
	public Shield parent;
	void Update() {
		segmentHP += segmentRegenRate;
		if(segmentHP > segmentMaxHP) {
			segmentHP = segmentMaxHP;
		}
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (float) (segmentHP/segmentMaxHP));
	}
	public void Damage(double damage) {
		segmentHP -= damage;
		if(!(segmentHP > 0)) {
			parent.OnSegmentDestroyed();
			Destroy(gameObject);
		}
	}
}
