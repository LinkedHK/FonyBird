using UnityEngine;
using System.Collections;

public class BgLooper : MonoBehaviour {



    private GameObject[] ground;
    private GameObject[] sky;
    private Transform player;

    int panel_num = 7;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        ground = GameObject.FindGameObjectsWithTag("ground");
        sky = GameObject.FindGameObjectsWithTag("sky");
	}
    void syncBgPosition(ref GameObject[] bg, float speed)
    {
        foreach (GameObject b in bg)
        {
            Vector3 d = b.transform.position;
            d.x += speed * Time.deltaTime;
            b.transform.position = d;

        }
    }

    void FixedUpdate()
    {

        float pl_vel = player.transform.rigidbody2D.velocity.x;
        syncBgPosition(ref ground, -pl_vel);
        syncBgPosition(ref sky, pl_vel * 0.9f);

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
    
        float coll_width = coll.bounds.size.x;
        Vector3 coll_pos = coll.transform.position;
        // How far coll should have been moved; Take panel num multiplied by 7

        if (coll.tag == "sky") {
            coll_pos.x += coll_width * panel_num + coll_width/2f;
        }
        else if (coll.tag == "ground")
        {
            coll_pos.x += coll_width * panel_num - coll_width;
        }
     
        coll.transform.position = coll_pos;
    }

}
