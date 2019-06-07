using UnityEngine;
using System.Collections;

public class ASwordA : MonoBehaviour {

	int movespeed = 7;
	public Transform Body;
	public Transform Switch;
	public Transform Switch1;


	void Update (){
		if (Switch.position == Body.TransformPoint(0,0,0) && Switch1.position == Body.TransformPoint (1,0,0)) {
			//transform.rotation = Controller1.playerro;
			transform.position = Vector3.Lerp (transform.position,  Body.TransformPoint(1.5f,0,1), movespeed * Time.deltaTime);
			transform.Rotate (Vector3.down * Time.deltaTime * -180, Space.Self);
			//StartCoroutine ("Wait");
		}
		if (Switch.position == Body.TransformPoint (1,0,0) && Switch1.position == Body.TransformPoint (1,0,0)) {
			//transform.rotation = Controller1.playerro;
			transform.position = Vector3.Lerp (transform.position, Body.TransformPoint(-1.5f,0,1), movespeed * Time.deltaTime);
			transform.Rotate (Vector3.down * Time.deltaTime * 180, Space.Self);
			//StartCoroutine ("Wait");
		}
		if (Switch.position == Body.TransformPoint (2,0,0) && Switch1.position == Body.TransformPoint (1,0,0)) {
			transform.rotation = Body.rotation;
			transform.position = Vector3.Lerp (transform.position, Body.TransformPoint(-0.3f,0,1.7f), movespeed * Time.deltaTime);
			//StartCoroutine ("Wait");
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
	/*IEnumerator Wait(){
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
	}*/
}
