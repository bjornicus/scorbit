using UnityEngine;
using System.Collections.Generic;

public class Attractor : MonoBehaviour 
{	
	public float range = 1000;
	public float strength = 1;
	
	void FixedUpdate () 
	{
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 
		List<Rigidbody> rbs = new List<Rigidbody>();
		
		foreach(Collider c in cols)
		{
			Rigidbody rb = c.attachedRigidbody;
			if(rb != null && rb != GetComponent<Rigidbody>() && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				if (offset.magnitude !=0){
					rb.AddForce( offset / offset.sqrMagnitude * strength);
				}
			}
		}
	}
}