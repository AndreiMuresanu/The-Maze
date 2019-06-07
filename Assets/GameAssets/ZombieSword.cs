using UnityEngine;
using System.Collections;

public class ZombieSword : MonoBehaviour {

	public Transform sword;
	//Vector3 thePositionS;
	//Vector3 thePositionSA;
	//Vector3 thePositionSB;
	bool Scombo = true;
	//bool i = false;
	bool InSwingRange = false;
	bool SwingingSword = false;
	public Transform Switch;
	public Transform Switch1;
	public Transform Player;
	bool a = true;



	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "FollowRange" && a == true) {
			Player = other.gameObject.transform;
			a = false;
		}
		if (other.gameObject.name == "Player") {
			InSwingRange = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.name == "Player") {
			InSwingRange = false;
		} 
	}

	void Update () {
		//thePositionS = transform.TransformPoint(1,0,1.5f);
		//thePositionSA = transform.TransformPoint(-1,0,1.5f);
		//thePositionSB = transform.TransformPoint(0.5f,0,0.5f);
		if(Player == true && Switch.position != transform.TransformPoint(4,0,0)){
			if (InSwingRange == true && SwingingSword == false) {
				Scombo = !Scombo;
				SingleSwordClass();
			}
		}
	}

	void SingleSwordClass(){
		if(Scombo == false){
			//Instantiate (sword, thePositionS, Controller1.playerro);
			SwingingSword = true;
			sword.position = transform.TransformPoint(1,0,1.5f);
			Switch1.position = transform.TransformPoint (1,0,0);
			Switch.position = transform.TransformPoint (0,0,0);
			StartCoroutine ("Wait");
		}
		if(Scombo == true){
			//Instantiate (sword, thePositionSA, Controller1.playerro);
			SwingingSword = true;
			sword.position = transform.TransformPoint(-1,0,1.5f);
			Switch1.position = transform.TransformPoint (1,0,0);
			Switch.position = transform.TransformPoint (1,0,0);
			StartCoroutine ("Wait");
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.4f);
		Switch1.position = transform.TransformPoint (0,0,0);
		sword.rotation = transform.rotation;
		sword.position = transform.TransformPoint (0,-2,0);
		//yield return new WaitForSeconds (0.1f);
		SwingingSword = false;
		yield return null;
	}
}
