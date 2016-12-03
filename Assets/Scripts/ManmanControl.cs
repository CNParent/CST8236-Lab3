using UnityEngine;
using System.Collections;

public class ManmanControl : MonoBehaviour {

    public float movementForce;
    public float maxVelocity;
	
	// Update is called once per frame
	void Update () {
        var directions = new ArrayList();
        if (Input.GetKey(KeyCode.UpArrow))
            directions.Add(new Vector3(0.0f, 0.0f, 1.0f));
        if (Input.GetKey(KeyCode.RightArrow))
            directions.Add(new Vector3(1.0f, 0.0f, 0.0f));
        if (Input.GetKey(KeyCode.DownArrow))
            directions.Add(new Vector3(0.0f, 0.0f, -1.0f));
        if (Input.GetKey(KeyCode.LeftArrow))
            directions.Add(new Vector3(-1.0f, 0.0f, 0.0f));
        
        var body = GetComponent<Rigidbody>();
        if (directions.Count == 0 || body.velocity.magnitude > maxVelocity) return;

        var move = new Vector3(0.0f, 0.0f, 0.0f);
        foreach (Vector3 direction in directions)
            move += direction;

        move.Normalize();
        body.AddForce(move * movementForce, ForceMode.Acceleration);
	}
}
