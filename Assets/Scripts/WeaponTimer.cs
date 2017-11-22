using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponTimer : MonoBehaviour {
    public GameObject weaponIconObject;
    private Image weaponIcon;
    public GameObject weaponObject;
    private IWeapon weapon;
    private Image timer;
	void Start() {
        /*
        weaponImageObject = new GameObject("Weapon Icon", typeof(RectTransform));
        RectTransform weaponImageTransform = weaponImageObject.GetComponent<RectTransform>();
        weaponImageTransform.parent = gameObject.GetComponent<RectTransform>();
        weaponImageTransform.
        */
        timer = GetComponent<Image>();
        weaponIcon = weaponIconObject.GetComponent<Image>();
        Sprite weaponSprite = weaponObject.GetComponent<SpriteRenderer>().sprite;
        weaponIcon.sprite = weaponSprite;
        weaponIcon.rectTransform.sizeDelta = new Vector2(weaponSprite.bounds.size.x * weaponSprite.pixelsPerUnit, weaponSprite.bounds.size.y * weaponSprite.pixelsPerUnit);
        weaponIcon.rectTransform.eulerAngles = new Vector3(0, 0, 90);
        //weaponIcon.rectTransform.sizeDelta = new Vector2(48, 48);
        weapon = Helper.InitializeComponent<IWeapon>(weaponObject);
    }
	void Update () {
        //weaponIcon.rectTransform.eulerAngles = new Vector3(0, 0, weaponObject.transform.eulerAngles.z);
        timer.fillAmount = (float) weapon.GetCooldownLeft() / weapon.GetCooldown();
	}
}
