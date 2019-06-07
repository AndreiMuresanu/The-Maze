using UnityEngine;
using System.Collections;

public class MinotaurAxes : MonoBehaviour {

	public Transform sword;
	public Transform swordA;
	//Vector3 thePositionS;
	//Vector3 thePositionSA;
	//Vector3 thePositionSB;
	int Scombo = 2;
	int i = 0;
	bool InSwingRange = false;
	bool SwingingSword = false;
	public Transform Switch;
	public Transform Switch1;
	public Transform Player;
	bool a = true;



	void OnTriggerEnter (Collider other){
		if (other.gameObject.name == "Player") {
			InSwingRange = true;
		}
		if (other.gameObject.name == "FollowRange" && a == true) {
			Player = other.gameObject.transform;
			a = false;
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
				if (i < 1) {
					StopCoroutine ("ComboTimeCounter"); 
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo++;
					SingleSwordClass ();
				}
				if (i == 1){
					StopCoroutine ("ComboTimeCounter");
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo = 0;
					SingleSwordClass ();
				}
			}
		}
	}

	void SingleSwordClass(){
		if (Scombo == 3) {
			Scombo = 0;
		}
		if(Scombo == 0){
			//Instantiate (sword, thePositionS, Controller1.playerro);
			SwingingSword = true;
			sword.position = transform.TransformPoint(1,0,1.5f);
			swordA.position = transform.TransformPoint(-1,0,1.5f);
			Switch1.position = transform.TransformPoint (1,0,0);
			Switch.position = transform.TransformPoint (0,0,0);
			StartCoroutine ("Wait");
		}
		if(Scombo == 1){
			//Instantiate (sword, thePositionSA, Controller1.playerro);
			SwingingSword = true;
			sword.position = transform.TransformPoint(-1,0,1.5f);
			swordA.position = transform.TransformPoint(1,0,1.5f);
			Switch1.position = transform.TransformPoint (1,0,0);
			Switch.position = transform.TransformPoint (1,0,0);
			StartCoroutine ("Wait");
		}
		if(Scombo == 2){
			//Instantiate (sword, thePositionSB, Controller1.playerro);
			SwingingSword = true;
			sword.position = transform.TransformPoint(0.5f,0,0.5f);
			swordA.position = transform.TransformPoint(-0.5f,0,0.5f);
			Switch1.position = transform.TransformPoint (1,0,0);
			Switch.position = transform.TransformPoint (2,0,0);
			StartCoroutine ("Wait");
		}
	}


	IEnumerator ComboTimeCounter(){
		while(i < 1)
		{
			yield return new WaitForSeconds(3);
			i++;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.32f);
		Switch1.position = transform.TransformPoint (0,0,0);
		sword.rotation = transform.rotation;
		swordA.rotation = transform.rotation;
		sword.position = transform.TransformPoint (0,-2,0);
		swordA.position = transform.TransformPoint (0,-2,0);
		yield return new WaitForSeconds (1.5f);
		SwingingSword = false;
		yield return null;
	}
}
