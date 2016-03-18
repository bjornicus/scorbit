using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour {
	public float StartingSpeed;

	// Use this for initialization
	void Start () {
		var body = GetComponent<Rigidbody> ();
		var direction = Vector3.Cross (body.position.normalized, Vector3.forward);
		body.velocity = direction * StartingSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
