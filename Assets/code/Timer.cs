using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	[SerializeField] float time;
	[SerializeField] GameObject timeOutPanel;

	private Text myText;

	private void Start(){
		myText = GetComponent<Text>();
		StartCoroutine( TimeDealer() );
		timeOutPanel.SetActive(false);
	}
	private IEnumerator TimeDealer(){
		while( time != 0 ){
			time -= 1;
			myText.text = ( (int) time/60 ) + ":" + time % 60;
			yield return new WaitForSeconds(1);
		}
		StartCoroutine( TimeOutAnimation() );
	}
	private IEnumerator TimeOutAnimation(){
		
		timeOutPanel.SetActive(true);
		timeOutPanel.transform.GetChild(0).GetComponent<Text>().enabled = false;

		RectTransform myRT = timeOutPanel.GetComponent<RectTransform>();
		float height = myRT.sizeDelta.y;

		myRT.sizeDelta = new Vector2(myRT.sizeDelta.x,1);

		while(myRT.sizeDelta.y < height){
			myRT.sizeDelta = myRT.sizeDelta + new Vector2(0,0.15f*myRT.sizeDelta.y);
			yield return new WaitForEndOfFrame();
		}
		timeOutPanel.transform.GetChild(0).GetComponent<Text>().enabled = true;

		yield return new WaitForSeconds(2);

		timeOutPanel.transform.GetChild(0).GetComponent<Text>().enabled = false;

		while(myRT.sizeDelta.y > 1){
			myRT.sizeDelta = myRT.sizeDelta - new Vector2(0,0.2f*myRT.sizeDelta.y);
			yield return new WaitForEndOfFrame();
		}
		Debug.Log("FIM");
		SceneManager.LoadScene("menu");
	}
}
