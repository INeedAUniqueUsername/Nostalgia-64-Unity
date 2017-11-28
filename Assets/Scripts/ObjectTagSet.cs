using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectTagSet : MonoBehaviour {
    public List<ObjectTag> tags = new List<ObjectTag>();
    public void AddTag(ObjectTag[] t) {
        foreach(ObjectTag tag in t) {
            tags.Add(tag);
        }
    }
	public bool HasTag(ObjectTag t) {
        return tags.Contains(t);
    }
}
public enum ObjectTag {
    Player,
    NPC,
    Starship,
    ShieldSegment,
    Energy,
    Matter,
}
