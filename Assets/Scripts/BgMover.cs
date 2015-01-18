using UnityEngine;
using System.Collections;

public class BgMover : MonoBehaviour {


   private GameObject[] ground;
   private GameObject[] sky;

   private Transform player;




  void Start()
  {
      player =  GameObject.FindGameObjectWithTag("Player").transform;
      ground  = GameObject.FindGameObjectsWithTag("ground");
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


}
