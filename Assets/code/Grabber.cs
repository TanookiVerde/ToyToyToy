using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	[SerializeField] private bool isLeft = true;
	[SerializeField] private float movingVelocity;

	private Rigidbody2D myRB2D;
	
	private void Start(){
		myRB2D = GetComponent<Rigidbody2D>();
	}
	private void Update(){
		if(isLeft){
			InputLeft();
		}else{
			InputRight();
		}
	}
	private void InputLeft(){
		if(Input.GetKey(KeyCode.W)){
			myRB2D.AddForce(Vector3.up*movingVelocity);
		}else if(Input.GetKey(KeyCode.S)){
			myRB2D.AddForce(Vector3.down*movingVelocity);
		}else if(Input.GetKey(KeyCode.A)){
			myRB2D.AddForce(Vector3.left*movingVelocity);
		}else if(Input.GetKey(KeyCode.D)){
			myRB2D.AddForce(Vector3.right*movingVelocity);
		}
	}
	private void InputRight(){
		if(Input.GetKey(KeyCode.UpArrow)){
			myRB2D.AddForce(Vector3.up*movingVelocity);
		}else if(Input.GetKey(KeyCode.DownArrow)){
			myRB2D.AddForce(Vector3.down*movingVelocity);
		}else if(Input.GetKey(KeyCode.LeftArrow)){
			myRB2D.AddForce(Vector3.left*movingVelocity);
		}else if(Input.GetKey(KeyCode.RightArrow)){
			myRB2D.AddForce(Vector3.right*movingVelocity);
		}
	}
}
