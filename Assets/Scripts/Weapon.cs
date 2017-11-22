using UnityEngine;

public class Weapon : MonoBehaviour, IUsable, IWeapon
{
    public Transform projectile;
    //public Vector3 projectileVelocity;
    public float projectileSpeed;
    public int cooldown;
    private int cooldownLeft;
    private bool active;
    public void SetActive(bool active) { this.active = active; }
    public bool GetActive() { return active; }
    public void Activate() {
        //print("Fire!");
        if (cooldownLeft > 0)
            return;
        cooldownLeft = cooldown;
        float fireAngle = transform.eulerAngles.z;
        Transform shot = Instantiate(projectile);
        Transform rootParent = Helper.getRootParent(transform);
        shot.GetComponent<Projectile>().owner = rootParent;
        shot.gameObject.SetActive(true);
        shot.position = transform.position + Helper.PolarOffset3(fireAngle, 0.5f);
        shot.eulerAngles = new Vector3(0, 0, fireAngle);
        Rigidbody2D rb = rootParent.GetComponent<Rigidbody2D>();
        Vector3 velocity = new Vector3(rb.velocity.x, rb.velocity.y) + Helper.PolarOffset3(fireAngle, projectileSpeed);
        //shot.GetComponent<Rigidbody2D>().velocity = velocity + Helper.RotatePointAroundOrigin(projectileVelocity, new Vector3(0, 0, fireAngle));
        shot.GetComponent<Rigidbody2D>().velocity = velocity;
    }
    void Start() {
    }
    void Update() {
        if (cooldownLeft > 0)
            cooldownLeft--;
        
    }
    //https://gamedev.stackexchange.com/questions/96964/how-to-correctly-draw-a-line-in-unity
    public Material line;
    void OnPostRender() {
        if(line == null) {
            return;
        }
        GL.Begin(GL.LINES);
        line.SetPass(0);
        GL.Color(new Color(0f, 0f, 0, 1f));
        GL.Vertex(transform.position);
        GL.Vertex(transform.position + Helper.PolarOffset3(transform.eulerAngles.z, 100));
        GL.End();
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

    public float GetPowerUse() {
        return 0;
    }
}