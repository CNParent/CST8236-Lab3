using UnityEngine;
using System.Collections.Generic;

public class HeckSplosion : MonoBehaviour {

    public GameObject explosion;
    public float explosionRadius;
    public float explosionForce;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name.Equals("Floor") || c.gameObject.name.Equals("Corral")) return; // No colliding with the floor or outer walls!

        var copy = GameObject.Instantiate(explosion);
        copy.transform.position = c.contacts[0].point;
        copy.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        copy.GetComponent<AudioSource>().Play();
        copy.GetComponent<ParticleSystem>().Play();

        // Apply explosive force to object collided with!
        c.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, c.contacts[0].point, explosionRadius);
    }
}
