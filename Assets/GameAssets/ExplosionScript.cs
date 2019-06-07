using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	void Start () {
		StartCoroutine ("Wait");
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.7f);
		Destroy (gameObject);
	}
}
