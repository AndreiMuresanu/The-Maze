using UnityEngine;
using System.Collections;

public class GhostFollow : MonoBehaviour {


	int movespeed = 7;
	public Transform target;
	bool InRange = false;
	bool a = true;
	public Transform Switch;
	public Transform SwitchA;


	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "FollowRange") {
			if(a == true){
				//Debug.Log ("Touched FollowRange");
				//target = other.gameObject.GetComponentInParent<Transform>();
				target = other.gameObject.transform;
				a = false;
			}
			InRange = true;
		} 
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "FollowRange") {
			InRange = false;
		} 
	}

	void Update (){
		if (SwitchA.position == transform.TransformPoint (3, 0, 0)) {
			movespeed = 4;
		}
		else{
			movespeed = 7;
		}
		if(InRange == true){
			if(Switch.position != transform.TransformPoint (4,0,0)){
				transform.LookAt (target);
				transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
			}
		}
	}
}
