using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
	
	void LateUpdate () {
        gameObject.transform.position = player.transform.position + offset;
	}
}
