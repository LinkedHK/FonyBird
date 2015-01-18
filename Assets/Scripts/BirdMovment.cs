using UnityEngine;
using System.Collections;

public class BirdMovment : MonoBehaviour {

	// Use this for initialization
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;
    bool didFlap = false;
    public Vector3 flapVelocity;
    Vector3 velocety = Vector3.zero;

	void Start () {

	}
	
	// Update is called once per frame


	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }

	}

    // Physics here
    void FixedUpdate()
    {

        calculateFallVelocety();
        transform.rotation = calculateRotation();
    }

    Quaternion calculateRotation()
    {
        float angle = 0;
        if (velocety.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -rigidbody2D.velocity.y / maxSpeed);
        }
        return Quaternion.Euler(0, 0, angle);
    }
    void calculateFallVelocety()
    {

        velocety =rigidbody2D.velocity;

        velocety.x = forwardSpeed;
       
        if (didFlap == true)
        {
            didFlap = false;
            if (velocety.y < 0)
                velocety.y = 0;
            velocety += flapVelocity;
        }
        rigidbody2D.velocity = velocety;
    }


}
