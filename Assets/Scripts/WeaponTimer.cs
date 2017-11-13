using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponTimer : MonoBehaviour {
    private Image img;
    public GameObject weaponObject;
    private IWeapon weapon;
	void Start() {
        img = GetComponent<Image>();
        weapon = Helper.InitializeComponent<IWeapon>(weaponObject);
    }
	void Update () {
		
	}
}
