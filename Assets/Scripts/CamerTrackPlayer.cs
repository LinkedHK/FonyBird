using UnityEngine;
using System.Collections;

public class CamerTrackPlayer : MonoBehaviour {

    Transform player;
    Vector3 offset;
    public float smoothing = 5f;        // The speed with which the camera will be following.
	// Use this for initialization
	void Start () {

        GameObject player_obj = GameObject.FindGameObjectWithTag("Player");

        if (player_obj == null)
        {
            Debug.LogError("Couldn't find an object with tag player!");
            return;
        }
        player = player_obj.transform;
        // calculate initial camera position
        offset = transform.position - player.position;
	
	}

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x + offset.x;
            transform.position = pos;
        }
     
    }
	
	// Update is called once per frame
	void Update () {
        /*

        if (player != null)
        {
            Vector3 pos = transform.position;


            transform.position = new Vector3(Mathf.Abs(offsetX), transform.position.y, transform.position.z);

        }

        */
    }
}
