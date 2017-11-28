using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	public int segmentCount;
	public float segmentSpan;
	public Sprite segmentSprite;
	public float radius;
	private List<Transform> segments;
	public int segmentCreateTime;
	private int segmentCreateTimeLeft;
	public double segmentMaxHP;
	public double segmentRegenRate;
	void Start() {
		segments = new List<Transform>(segmentCount);
		for(int i = 0; i < segmentCount; i++) {
			segments.Add(null);
		}
		segmentCreateTimeLeft = segmentCreateTime;
	}
	void Update() {
		//print("Shield: Update");
		if(segmentCreateTimeLeft > 0) {
			segmentCreateTimeLeft--;
		} else {
			print("Ready to create new segment");
			segmentCreateTimeLeft = segmentCreateTime;
			int centerSegmentIndex = segmentCount/2;
			for(int i = 0; i < segments.Count; i++) {
				if(segments[i] == null) {
					print("Create new segment");
					int segmentCreateIndex = i;
					GameObject segmentToCreate = new GameObject();
					segmentToCreate.SetActive(true);
					segmentToCreate.transform.parent = gameObject.transform;
					float angleOffset = (i - centerSegmentIndex) * segmentSpan;
					float segmentAngle = angleOffset;
					segmentToCreate.transform.localPosition = Helper.PolarOffset2(segmentAngle, radius);
					segmentToCreate.transform.localEulerAngles = new Vector3(0, 0, segmentAngle);
					SpriteRenderer spriteRenderer = segmentToCreate.AddComponent<SpriteRenderer>();
					spriteRenderer.sprite = segmentSprite;
					spriteRenderer.color = new Color(1, 1, 1, 0);
					segmentToCreate.AddComponent<PolygonCollider2D>().isTrigger = true;
					ShieldSegment segmentComponent = segmentToCreate.AddComponent<ShieldSegment>();
					segmentComponent.parent = this;
					segmentComponent.segmentMaxHP = segmentMaxHP;
					segmentComponent.segmentRegenRate = segmentRegenRate;

					segmentToCreate.AddComponent<ObjectTagSet>().AddTag(new ObjectTag[] {ObjectTag.ShieldSegment, ObjectTag.Energy});

					segments[segmentCreateIndex]  = segmentToCreate.transform;
					break;
				}
			}
		}
	}
	public void OnSegmentDestroyed() {
		//If we had all our segments before losing one, then we reset our segment creation timer
		for(int i = 0; i < segments.Count; i++) {
			if(segments[i] == null) {
				return;
			}
		}
		segmentCreateTimeLeft = segmentCreateTime;
	}
}