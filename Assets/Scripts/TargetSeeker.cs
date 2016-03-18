using UnityEngine;
using System.Collections;

public class TargetSeeker : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Target")
		{
			var relativeVelocty = (GetComponent<Rigidbody>().velocity - other.GetComponent<Rigidbody>().velocity);

			if (relativeVelocty.magnitude < 1)
			{
				Destroy (other.gameObject);
			}
			else
			{
				Destroy (gameObject);
			}
		}
				
	}
}
