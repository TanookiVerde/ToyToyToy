using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<Toy>() != null){
			StartCoroutine( other.GetComponent<Toy>().GetSmall() );
			StartCoroutine( Whummy() );
		}
	}
	public IEnumerator Whummy(){
		yield return new WaitForSeconds(0.1f);
		for(int i = 5; i>0;i--){
			transform.localScale = new Vector3 (transform.localScale.x*0.97f,transform.localScale.y, 1);
			yield return new WaitForSeconds(0.01f);
		}
		for(int i = 5; i>0;i--){
			transform.localScale = new Vector3 (transform.localScale.x*1.03f,transform.localScale.y, 1);
			yield return new WaitForSeconds(0.01f);
		}
	}
}
