using UnityEngine;
using System.Collections;

public class MinotaurDestruction : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "Destructible" && MinotaurMovement.Charge == true) {
			Destroy (other.gameObject);
		}
	}
}
