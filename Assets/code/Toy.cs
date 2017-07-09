using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour {
	public bool grabbed = false;
	private Animator myAnimator;
	private Rigidbody2D myRB2D;
	private bool lastGrabbed;

	private void Start(){
		myAnimator = GetComponent<Animator>();
		myRB2D = GetComponent<Rigidbody2D>();
		lastGrabbed = grabbed;
	}
	private void Update(){
		GrabbedRightNow();
	}
	public IEnumerator GetSmall(){
		for(int i = 20; i>0;i--){
			transform.localScale = transform.localScale*0.9f;
			yield return new WaitForEndOfFrame();
		}
		Destroy(gameObject);
	}

	//TODA A PARTE DE ANIMACAO ESTA ERRADA, MAS ATE QUE NAO ESTA RUIM NO JOGO KKKKKK DEPOIS CONSERTO
	public void AnimationDealer(){
		if(grabbed){
			myAnimator.SetTrigger("grabbed");
			grabbed = false;
		}
	}
	private bool isBeenGrabbed(){
		if(myRB2D.velocity.magnitude > 0.2){
			return true;
		}
		return false;
	}
	private void GrabbedRightNow(){
		grabbed = isBeenGrabbed();
		if(lastGrabbed == false && grabbed == true){
			AnimationDealer();
		}
		lastGrabbed = grabbed;
	}

	private void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Bullet")){
			StartCoroutine( GetSmall() );
		}
	}
}
