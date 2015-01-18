using UnityEngine;
using System.Collections;

public class CamPusher : MonoBehaviour {

  //  Transform player;

    int panel_num = 6;
	// Use this for initialization
	void Start () {

  //      player = GameObject.FindGameObjectWithTag("Player").transform;

	
	}


    void FixedUpdate()
    {

       

      /*  stop If bird speed 0*/

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        float coll_width = ((BoxCollider2D)coll).size.x;
        Vector3 coll_pos = coll.transform.position;
        // How far coll should have been moved; Take panel num multiplied by 6
        coll_pos.x += coll_width * panel_num - coll_width/2f+2;
        coll.transform.position = coll_pos;
    }

}
