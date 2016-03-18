using UnityEngine;
using System.Collections;

public class DynamicZoom : MonoBehaviour {

	public Transform keepInView;

	private Camera theCamera;
	// Use this for initialization
	void Start () {
		theCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (keepInView != null) {
			theCamera.orthographicSize = Mathf.Clamp (keepInView.position.magnitude + 2, 15, 100);
		}
	}
}
