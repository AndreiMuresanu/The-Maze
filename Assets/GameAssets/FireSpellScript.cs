using UnityEngine;
using System.Collections;

public class FireSpellScript : MonoBehaviour {

	int movespeed = 50;
	bool CoroutineStarted = false;
	public GameObject Explosion;

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		if (CoroutineStarted == false){
			StartCoroutine ("Wait");
		}
	}
		
	IEnumerator Wait(){
		CoroutineStarted = true;
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "AttackerBody") {
			Instantiate(Explosion,gameObject.transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
	}
}