using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

	[SerializeField] private GameObject toyPrefab;
	[SerializeField] private int numberOfToys;
	[SerializeField] private float timeBetweenToys;

	private void Start(){
		StartCoroutine( MakeLevelToys() );
	}
	private IEnumerator MakeLevelToys(){
		int createdToys = 0;
		while(createdToys != numberOfToys){
			GameObject newToy =	Instantiate(toyPrefab,transform.position,Quaternion.identity);
			newToy.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,1f),
																	Random.Range(0,1f),
																	Random.Range(0,1f),
																	1f);
			StartCoroutine( Whummy() );
			createdToys++;
			yield return new WaitForSeconds(timeBetweenToys);
			
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
