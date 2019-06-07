using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	
	int movespeed = 20;
	int Dmovespeed = 15;
	public static bool AntiSpam = false;
	public static bool TwoSwordsInHand = false;
	public static bool SwordIsAlive;


	void Start(){
		SwordIsAlive = true;
		AntiSpam = true;
	}

	void Update (){
		if (TwoSwordsInHand == false) {
			if (SwordSwing.Scombo == 0) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndApos.SwordEndposA, movespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * 180);
				StartCoroutine ("Wait");
			}
			if (SwordSwing.Scombo == 1) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndBpos.SwordEndposB, movespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * -180);
				StartCoroutine ("Wait");
			}
			if (SwordSwing.Scombo == 2) {
				transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndCpos.SwordEndposC, movespeed * Time.deltaTime);
				StartCoroutine ("Wait");
			}
		}
		if (TwoSwordsInHand == true){
			if (SwordSwing.SDcombo == 0) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndApos.SwordEndposA, Dmovespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * 180);
				StartCoroutine ("WaitD");
			}
			if (SwordSwing.SDcombo == 1) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndBpos.SwordEndposB, Dmovespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * -180);
				StartCoroutine ("WaitD");
			}
			if (SwordSwing.SDcombo == 2) {
				transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndCpos.SwordEndposC, Dmovespeed * Time.deltaTime);
				StartCoroutine ("WaitD");
			}
		}
	}
	/*
	void OnTriggerEnter (Collider other){
		//Debug.Log ("Ball has entered!");
		if(other.gameObject.name == "Attacker") {
			Health.health = Health.health - 50;
			//Destroy (other.gameObject);
		}
	}
	*/
	IEnumerator Wait(){
		yield return new WaitForSeconds (0.1f);
		SwordIsAlive = false;
		Destroy (gameObject);
		AntiSpam = false;
	}

	IEnumerator WaitD(){
		yield return new WaitForSeconds (0.15f);
		SwordIsAlive = false;
		Destroy (gameObject);
		AntiSpam = false;
	}
}
