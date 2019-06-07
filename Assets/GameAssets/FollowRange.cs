using UnityEngine;
using System.Collections;

public class FollowRange : MonoBehaviour {

	public static bool InRange = false;

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "Attacker") {
			InRange = true;
		} 
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "Attacker") {
			InRange = false;
		} 
	}
}
