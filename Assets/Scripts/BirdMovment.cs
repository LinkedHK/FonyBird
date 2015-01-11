using UnityEngine;
using System.Collections;

public class BirdMovment : MonoBehaviour {

	// Use this for initialization

    
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;
    bool didFlap = false;
    Vector3 velocety = Vector3.zero;

	void Start () {
        //transform.position = new Vector3(0f, 0f, camera.ScreenToWorldPoint(new Vector3(0f, 0f, 1f)).z);
       
	}
	
	// Update is called once per frame


	void Update () {

        // Do graphic and input updates here.

        // GetMouseButtonDown 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }

	}

    // Physics here
    void FixedUpdate()
    {

        calculateFallVelocety();
        transform.rotation =  calculateRotation();
   
     
    }
    Quaternion calculateRotation()
    {
        float angle = 0;
        if (velocety.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocety.y / maxSpeed);
        }
        return Quaternion.Euler(0, 0, angle);
    }
    void calculateFallVelocety()
    { 
        velocety.x = forwardSpeed;
        // Fall velocety
        velocety += gravity * Time.deltaTime;
        // Forward velocety
       
        if (didFlap == true)
        {
            didFlap = false;
            if (velocety.y < 0)
                velocety.y = 0;
            velocety += flapVelocity;
        }
        
        velocety = Vector3.ClampMagnitude(velocety, maxSpeed);
        transform.position += velocety * Time.deltaTime;
       
    }

}
