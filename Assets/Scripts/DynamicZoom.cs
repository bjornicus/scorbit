using UnityEngine;
using System.Collections;

public class DynamicZoom : MonoBehaviour {

	public Transform keepInView;

	private float previousCameraSize;
	private float targetCameraSize;
	private float startTime;
	private float duration = 0.5f;

	private Camera theCamera;
	// Use this for initialization
	void Start () {
		theCamera = GetComponent<Camera> ();
		previousCameraSize = targetCameraSize = theCamera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (keepInView != null) {
			var desiredCameraSize = Mathf.Clamp(Mathf.NextPowerOfTwo(Mathf.RoundToInt(keepInView.position.magnitude)),16, 64);
			if (desiredCameraSize != targetCameraSize) {
				startTime = Time.time;
				targetCameraSize = desiredCameraSize;
				previousCameraSize = theCamera.orthographicSize;
			}
			float t = (Time.time - startTime) / duration;
			theCamera.orthographicSize = Mathf.SmoothStep(previousCameraSize, targetCameraSize, t);	
		}
	}
}
