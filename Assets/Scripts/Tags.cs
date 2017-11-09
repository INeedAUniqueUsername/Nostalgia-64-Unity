using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour {
    public enum Tag {
        Player,
        NPC,

        SpaceObject,
        Starship,
        Projectile
    }
    public List<Tag> tags;
	public bool HasTag(Tag t) {
        return tags.Contains(t);
    }
}
