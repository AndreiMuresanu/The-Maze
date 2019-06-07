using UnityEngine;
using System.Collections;

public class SwordLeft : MonoBehaviour {
	
	int movespeed = 20;
	int Dmovespeed = 15;

	void Start(){
		Sword.SwordIsAlive = true;
		Sword.AntiSpam = true;
	}

	void Update (){
		if(Sword.TwoSwordsInHand == true){
			if (SwordSwing.SDcombo == 0) {
				//transform.rotation = Controller.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndBpos.SwordEndposB, Dmovespeed * Time.deltaTime);
				transform.Rotate(Vector3.down * Time.deltaTime*-180);
				StartCoroutine ("WaitD");
			}
			if (SwordSwing.SDcombo == 1) {
				//transform.rotation = Controller.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndApos.SwordEndposA, Dmovespeed * Time.deltaTime);
				transform.Rotate(Vector3.down * Time.deltaTime*180);
				StartCoroutine ("WaitD");
			}
			if (SwordSwing.SDcombo == 2) {
				transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndDpos.SwordEndposD, Dmovespeed * Time.deltaTime);
				StartCoroutine ("WaitD");
			}
		}
		if (Sword.TwoSwordsInHand == false) {
			if (SwordSwing.Scombo == 0) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndBpos.SwordEndposB, movespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * -180);
				StartCoroutine ("Wait");
			}
			if (SwordSwing.Scombo == 1) {
				//transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndApos.SwordEndposA, movespeed * Time.deltaTime);
				transform.Rotate (Vector3.down * Time.deltaTime * 180);
				StartCoroutine ("Wait");
			}
			if (SwordSwing.Scombo == 2) {
				transform.rotation = Controller1.playerro;
				transform.position = Vector3.Lerp (transform.position, SwordEndDpos.SwordEndposD, movespeed * Time.deltaTime);
				StartCoroutine ("Wait");
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
		Sword.SwordIsAlive = false;
		Destroy (gameObject);
		Sword.AntiSpam = false;
	}

	IEnumerator WaitD(){
		yield return new WaitForSeconds (0.15f);
		Sword.SwordIsAlive = false;
		Destroy (gameObject);
		Sword.AntiSpam = false;
	}
}
