using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float movingVelocity;
	[SerializeField] private Vector2 maxScale,minScale;
	[SerializeField] private float timeToComeBack,breathingTime;

	private Rigidbody2D myRB2D;

	[SerializeField] private bool shooting, up, bigger,shootLeft;

	private void Start(){
		myRB2D = GetComponent<Rigidbody2D>();
		StartCoroutine( BubbleDirection() );

	}
	private void Update(){
		if(up){
			myRB2D.AddForce(Vector2.up*movingVelocity);
		}else{
			myRB2D.AddForce(Vector2.down*movingVelocity);
		}
		
	}
	private IEnumerator BubbleDirection(){
		while(true){
			yield return new WaitForSeconds(timeToComeBack);
			up = !up;
			StartCoroutine( ShootingAnimation() );
		}
	}
	private IEnumerator ShootingAnimation(){
		shooting = true;
		for(int i = 10; i > 0; i--){
			transform.localScale = new Vector3(transform.localScale.x*0.97f,transform.localScale.y,1);
			yield return new WaitForEndOfFrame();
		}
		
		if(shootLeft){
			Instantiate(bulletPrefab,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(Vector2.left*500);
		}
		if(!shootLeft){
			Instantiate(bulletPrefab,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(Vector2.right*500);
		}
		for(int i = 10; i > 0; i--){
			transform.localScale = new Vector3(transform.localScale.x*1.03f,transform.localScale.y,1);
			yield return new WaitForEndOfFrame();
		}
		shooting = false;

	}
}
