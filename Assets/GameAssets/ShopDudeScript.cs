using UnityEngine;
using System.Collections;

public class ShopDudeScript : MonoBehaviour {

	public Transform Player;
	bool a = true;

	void Update () {
		if(Player != null){
			transform.LookAt(Player.position);
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "FollowRange") {
			if(a == true){
				//Debug.Log ("Touched FollowRange");
				//target = other.gameObject.GetComponentInParent<Transform>();
				Player = other.gameObject.transform;
				a = false;
			}
		} 
	}
}
