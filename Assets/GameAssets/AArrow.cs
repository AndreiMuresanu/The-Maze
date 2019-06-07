using UnityEngine;
using System.Collections;

public class AArrow : MonoBehaviour {

	int movespeed = 35;
	bool CoroutineStarted = false;

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		if (CoroutineStarted == false){
			StartCoroutine ("Wait");
		}
	}
		
	IEnumerator Wait(){
		CoroutineStarted = true;
		yield return new WaitForSeconds (0.5f);
		//if (Hit == false) {
			Destroy (gameObject);
		//}
	}
}
