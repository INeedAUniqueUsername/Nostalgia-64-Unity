using UnityEngine;

public class Weapon : MonoBehaviour, IDevice, IWeapon
{
    public Transform projectile;
    //public Vector3 projectileVelocity;
    public float projectileSpeed;

    public int cooldown;
    private int cooldownLeft;

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
        Vector3 velocity = new Vector3(rb.velocity.x, rb.velocity.y) + Helper.PolarOffset(fireAngle, projectileSpeed);
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
        GL.Vertex(transform.position + Helper.PolarOffset(transform.eulerAngles.z, 100));
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
}