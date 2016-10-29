using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Transform car;

	public Vector3 wantedPos;
	public float distance = 6.4f;
	public float height = 1.4f;
	public float rotationDamping = 3.0f;
	public float heightDamping = 2.0f;
	public float zoonRacio = 0.5f;
	private Vector3 roationVector;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void LateUpdate () {

		float wantedAngel = car.eulerAngles.y;
		float wantedHeight = car.position.y + height;
		float myAngel = transform.eulerAngles.y;
		float myHeight = transform.position.y;

		myAngel = Mathf.LerpAngle (myAngel, wantedAngel, rotationDamping * Time.deltaTime);
		myHeight = Mathf.Lerp (myHeight, wantedHeight, heightDamping * Time.deltaTime);

		var currentRotation = Quaternion.Euler (0f,myAngel, 0f);
		transform.position = car.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		transform.position = new Vector3 (transform.position.x, myHeight, transform.position.z);

		transform.LookAt (car);

	}
}