using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decelerator : MonoBehaviour, IUsable {
    public float linearSpeedInc;
    public float angularSpeedInc;
    public virtual void Activate() {
        Decelerate();
    }
    public void Decelerate() {
        Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float x = velocity.x;
        float xInc = Mathf.Min(Mathf.Abs(x), linearSpeedInc);
        float y = velocity.y;
        float yInc = Mathf.Min(Mathf.Abs(y), linearSpeedInc);
        if (x < 0)
            x += xInc;
        else if (x > 0)
            x -= xInc;
        if (y < 0)
            y += yInc;
        else if (y > 0)
            y -= yInc;
        rb.velocity = new Vector2(x, y);

        float r = rb.angularVelocity;
        float rInc = Mathf.Min(Mathf.Abs(r), angularSpeedInc);
        if (r < 0)
            r += rInc;
        else if (r > 0)
            r -= rInc;
        rb.angularVelocity = r;
    }
}
