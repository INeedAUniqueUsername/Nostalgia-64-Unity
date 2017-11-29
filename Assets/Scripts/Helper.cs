using UnityEngine;
using System;
using System.Collections.Generic;

public static class Helper {
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        //http://answers.unity3d.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
    public static Vector3 RotatePointAroundOrigin(Vector3 point, Vector3 angles)
    {
        //http://answers.unity3d.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        return Quaternion.Euler(angles) * point;
    }
    public static Vector2 PolarOffset2(float angle, float distance) {
        return new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad) * distance, Mathf.Sin(angle*Mathf.Deg2Rad)*distance);
    }
    public static Vector3 PolarOffset3(float angle, float distance) {
        Vector2 v = PolarOffset2(angle, distance);
        return new Vector3(v.x, v.y);
    }
    public static bool isRelated(Transform parent, Transform obj) {
        Transform objParent = obj;
        do {
            if (objParent == parent) {
                return true;
            }
            objParent = objParent.parent;
        } while (objParent);
        return false;
    }
    public static Transform getRootParent(Transform obj) {
        Transform parent = obj;
        Transform nextParent = parent.parent;
        while(nextParent) {
            parent = nextParent;
            nextParent = parent.parent;
        }
        return parent;
    }
    public static T InitializeComponent<T>(GameObject obj) {
        if (obj == null) {
            throw new Exception("Invalid Component object");
        }
        T result = obj.GetComponent<T>();
        if (result == null) {
            throw new Exception("Invalid Component instance");
        }
        return result;
    }
    public static List<T> InitializeComponent<T>(List<GameObject> objList) {
        List<T> result = new List<T>(objList.Count);
        for (int i = 0; i < objList.Count; i++) {
            GameObject obj = objList[i];
            if(obj == null) {
                throw new Exception("Invalid Component object");
            }
            T component = obj.GetComponent<T>();
            if(component == null) {
                throw new Exception("Invalid Component instance");
            }
            result.Add(component);
        }
        return result;
    }
    public static void TurnTo(GameObject obj, float degrees, float angledSpeed) {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        velocity += Helper.PolarOffset2(degrees, angledSpeed);
        rb.velocity = velocity;
    }
    public static void DrawHexagon(Vector3 center, float rotation, float radius) {
        Vector3 previous = center + PolarOffset3(rotation, radius);
        for(int i = 1; i < 7; i ++) {
            float angle = rotation + i * 60;
            Vector3 point = center + PolarOffset3(angle, radius);
            Gizmos.DrawLine(previous, point);
            previous = point;
        }
    }
    public static float GetAngleDiffMin(float start, float end) {
        return Mathf.Min(GetAngleDiffLeft(start, end), GetAngleDiffRight(start, end));
    }
    public static float GetAngleDiffRight(float start, float end) {
        return ModDegrees(start - end);
    }
    public static float GetAngleDiffLeft(float start, float end) {
        return ModDegrees(end - start);
    }
    public static float ModDegrees(float degrees) {
        float result = degrees;
        while(result < 0) {
            result += 360;
        }
        while(result > 360) {
            result -= 360;
        }
        return result;
    }
    public static float GetTorque(Vector3 objectPosition, Vector3 forcePosition, Vector3 force) {
        float radius = (objectPosition - forcePosition).magnitude;
        float forceMagnitude = force.magnitude;
        float angle = Vector3.Angle(forcePosition, objectPosition) - Vector3.Angle(Vector3.zero, force);
        return radius * forceMagnitude * Mathf.Sin(angle * Mathf.Deg2Rad);
    }
    //https://answers.unity.com/answers/26511/view.html
	public static void SetLayer(Transform root, int layer) {
		root.gameObject.layer = layer;
		foreach(Transform child in root)
			SetLayer(child, layer);
	}
    public static Vector2 CalcInterceptShotVelocity(Vector2 pos_diff, Vector2 vel_diff, float speed /*Vector2 p1, Vector2 v1, Vector2 p2, Vector2 v2, float speed*/) {
        return CalcInterceptPosDiff(pos_diff, vel_diff, speed).normalized * speed;

        //https://stackoverflow.com/a/22117046
        /*
        I find the easiest approach to these kind of problems to make sense of them first, and have a basic high school level of maths will help too.

        Solving this problem is essentially solving 2 equations with 2 variables which are unknown to you:

        The vector you want to find for your projectile (V)
        The time of impact (t)
        The variables you know are:

        The target's position (P0)
        The target's vector (V0)
        The target's speed (s0)
        The projectile's origin (P1)
        The projectile's speed (s1)
        Okay, so the 1st equation is basic. The impact point is the same for both the target and the projectile. It is equal to the starting point of both objects + a certain length along the line of both their vectors. This length is denoted by their respective speeds, and the time of impact. Here's the equation:

        P0 + (t * s0 * V0) = P1 + (t * s0 * V)
        Notice that there are two missing variables here - V & t, and so we won't be able to solve this equation right now. On to the 2nd equation.

        The 2nd equation is also quite intuitive. The point of impact's distance from the origin of the projectile is equal to the speed of the projectile multiplied by the time passed:

        We'll take a mathematical expression of the point of impact from the 1st equation:

        P0 + (t * s0 * V0) <-- point of impact
        The point of origin is P1 The distance between these two must be equal to the speed of the projectile multiplied by the time passed (distance = speed * time).

        The formula for distance is: (x0 - x1)^2 + (y0 - y1)^2 = distance^2, and so the equation will look like this:

        ((P0.x + s0 * t * V0.x) - P1.x)^2 + ((P0.y + s0 * t * V0.y) - P1.y)^2 = (s1 * t)^2 
        (You can easily expand this for 3 dimensions)

        Notice that here, you have an equation with only ONE unknown variable: t!. We can discover here what t is, then place it in the previous equation and find the vector V.

        Let me solve you some pain by opening up this formula for you (if you really want to, you can do this yourself).

        a = (V0.x * V0.x) + (V0.y * V0.y) - (s1 * s1)
        b = 2 * ((P0.x * V0.x) + (P0.y * V0.y) - (P1.x * V0.x) - (P1.y * V0.y))
        c = (P0.x * P0.x) + (P0.y * P0.y) + (P1.x * P1.x) + (P1.y * P1.y) - (2 * P1.x * P0.x) - (2 * P1.y * P0.y)

        t1 = (-b + sqrt((b * b) - (4 * a * c))) / (2 * a)
        t2 = (-b - sqrt((b * b) - (4 * a * c))) / (2 * a)
        Now, notice - we will get 2 values for t here.

        One or both may be negative or an invalid number. Obviously, since t denotes time, and time can't be invalid or negative, you'll need to discard these values of t.

        It could very well be that both t's are bad (in which case, the projectile cannot hit the target since it's faster and out of range). It could also be that both t's are valid and positive, in which case you'll want to choose the smaller of the two (since it's preferable to hit the target sooner rather than later).

        t = smallestWhichIsntNegativeOrNan(t1, t2)
        Now that we've found the time of impact, let's find out what the direction the projectile should fly is. Back to our 1st equation:

        P0 + (t * s0 * V0) = P1 + (t * s0 * V)
        Now, t is no longer a missing variable, so we can solve this quite easily. Just tidy up the equation to isolate V:

        V = (P0 - P1 + (t * s0 * V0)) / (t * s1)
        V.x = (P0.x - P1.x + (t * s0 * V0.x)) / (t * s1) 
        V.y = (P0.y - P1.y + (t * s0 * V0.y)) / (t * s1) 
        And that's it, you're done! Assign the vector V to the projectile and it will go to where the target will be rather than where it is now.

        I really like this problem since it takes math equations we learnt in high school where everyone said "why are learning this?? we'll never use it in our lives!!", and gives them a pretty awesome and practical application.

        I hope this helps you, or anyone else who's trying to solve this.
        */
        /*
        Vector2 p_diff = p1 - p2;
        float a = (v2.x * v2.x) + (v2.y * v2.y) - (speed * speed);
        float b = 2 * ((p_diff.x * v2.x) + (p_diff.y * v2.y));
        float c = (p_diff.x * p_diff.x) + (p_diff.y * p_diff.y);

        float t1 = (-b + Mathf.Sqrt((b * b) - (4 * a * c))) / (2 * a);
        float t2 = (-b - Mathf.Sqrt((b * b) - (4 * a * c))) / (2 * a);

        bool t1_positive = t1 > 0;
        bool t2_positive = t2 > 0;
        
        float t = -1;

        if(t1_positive && t2_positive) {
            if(t1 < t2) {
                t = t1;
            } else if(t2 < t1) {
                t = t2;
            }
        } else if(t1_positive) {
            t = t1;
        } else if(t2_positive) {
            t = t2;
        }

        if(t > 0) {
            //Adjust for framerate
            float s2 = v2.magnitude;
            return (speed/30) * ((p2 - p1 + (t * s2 * v2)) / (t * speed));
        } else {
            return Vector2.zero;
        }
        */
    }
    public static Vector2 CalcInterceptPosDiff(Vector2 pos_diff, Vector2 vel_diff, float speed) {
        Vector2 origin = Vector2.zero;
		//Here is our initial estimate. If the target is moving, then by the time the shot reaches the target's original position, the target will be somnewhere else
		
        float time_to_hit_estimate = (origin - pos_diff).magnitude / speed;
		Vector2 pos_diff_future = pos_diff + (vel_diff * time_to_hit_estimate);
		
		float time_to_hit_previous = 0;
        float precision_previous = 1000;
		for(int i = 1; i < 20; i++) {
			float time_to_hit = (origin - pos_diff_future).magnitude / speed;
			pos_diff_future = pos_diff + (vel_diff * time_to_hit);
			
			//System.out.println("Try " + i);
			//System.out.println("Time to Hit: " + time_to_hit);
			float precision = Mathf.Abs(time_to_hit - time_to_hit_previous);
			if(precision < 0.1) {
				return pos_diff_future;
			} else {
                precision_previous = precision;
                time_to_hit_previous = time_to_hit;
            }
		}
        return Vector2.zero;
    }
}