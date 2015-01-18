using UnityEngine;
using System.Collections;

public class BgCamFollower : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll)
    {
        float size_x = coll.bounds.size.x;
        Vector3 pos = coll.transform.position;
        pos.x += size_x * 6 + size_x / 2 + 1;
        coll.transform.position = pos;

    }
}
