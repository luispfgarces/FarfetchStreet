using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;

	void Awake(){
		
		anim = GetComponent<Animator> ();

		playerRigidBody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate(){

		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Animating (h, v);
	}

	void Move(float h, float v){

		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Animating(float h, float v){

		bool walking = h !=0f || v!=0f;
		anim.SetBool ("IsWalking", walking);
	}
}
