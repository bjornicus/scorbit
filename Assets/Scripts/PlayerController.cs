using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float thrustPower;
	public Boundary boundary;

	public bool useAltMoveScheme = false;

	public ParticleSystem rearThruster;
	public ParticleSystem frontThruster;
	public ParticleSystem rightrThruster;
	public ParticleSystem leftThruster;

	const int thrusterParticleCount = 20;

	void NormalMoveScheme (Rigidbody rigidbody)
	{
		var paralellDirection = rigidbody.velocity.normalized;
		var orthogonalDirection = Vector3.Cross (paralellDirection, Vector3.forward);
		AddThrust (rigidbody, paralellDirection, orthogonalDirection);

		var newRotation = rigidbody.rotation;
		newRotation.SetLookRotation (paralellDirection, Vector3.forward);
		rigidbody.rotation = newRotation;
	}

	void AltMoveScheme (Rigidbody rigidbody)
	{
		var orthogonalDirection = -1 * rigidbody.position.normalized;
		var paralellDirection = Vector3.Cross (orthogonalDirection, Vector3.back);
		AddThrust (rigidbody, paralellDirection, orthogonalDirection);
		
		var newRotation = rigidbody.rotation;
		newRotation.SetLookRotation (paralellDirection, Vector3.forward);
		rigidbody.rotation = newRotation;
	}

	void AddThrust (Rigidbody rigidbody, Vector3 paralellDirection, Vector3 orthogonalDirection)
	{
		float thrustOrthogonal = Input.GetAxis ("Horizontal");
		float thrustParalell = Input.GetAxis ("Vertical");
				
		rigidbody.AddForce (paralellDirection * thrustParalell * thrustPower);
		rigidbody.AddForce (orthogonalDirection * thrustOrthogonal * thrustPower);

		if (thrustParalell > 0) {
			rearThruster.Emit (thrusterParticleCount);
		}
		if (thrustParalell < 0) {
			frontThruster.Emit(thrusterParticleCount);
		}
		if (thrustOrthogonal > 0) {
			rightrThruster.Emit (thrusterParticleCount);
		}
		if (thrustOrthogonal < 0) {
			leftThruster.Emit (thrusterParticleCount);
		}
	}

	void FixedUpdate ()
	{
		var rigidbody = GetComponentInParent<Rigidbody> ();

		if (Input.GetButton("Fire1")){
			useAltMoveScheme = !useAltMoveScheme;
		};

		if (useAltMoveScheme) {
			AltMoveScheme (rigidbody);
		} else {
			NormalMoveScheme (rigidbody);
		}		
	}
}
