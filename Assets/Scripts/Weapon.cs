using UnityEngine;

public class Weapon : MonoBehaviour, IDevice, IWeapon
{
    public Transform projectile;
    public Vector3 projectileVelocity;

    public int cooldown;
    private int cooldownLeft;

    void Start() {
        //cooldownLeft = 0;
    }

    public void Activate() {
        if (cooldownLeft > 0)
            return;
        cooldownLeft = cooldown;
        float fireAngle = transform.eulerAngles.z;
        Transform shot = Instantiate(projectile);
        shot.GetComponent<Projectile>().SetOwner(gameObject.transform.parent);
        shot.gameObject.SetActive(true);
        shot.position = transform.position + Helper.PolarOffset(fireAngle, 0.5f);
        shot.eulerAngles = new Vector3(0, 0, fireAngle);
        Rigidbody2D rb = gameObject.transform.parent.GetComponent<Rigidbody2D>();
        Vector3 velocity = new Vector3(rb.velocity.x, rb.velocity.y);
        shot.GetComponent<Rigidbody2D>().velocity = velocity + Helper.RotatePointAroundOrigin(projectileVelocity, new Vector3(0, 0, fireAngle));
    }
    void Update() {
        if (cooldownLeft > 0)
            cooldownLeft--;
    }
    public int GetCooldown() {
        return cooldown;
    }
    public int GetCooldownLeft() {
        return cooldownLeft;
    }
    public bool IsReady() {
        return cooldownLeft > 0;
    }
    public Transform GetProjectile() {
        return projectile;
    }
}