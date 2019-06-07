using UnityEngine;
using System.Collections;

public class AttackerRanged : MonoBehaviour {

	bool InSwingRange = false;
	public Transform Player;
	bool a = true;
	public Transform arrow;
	public Transform Attacker;
	bool Reloading = false;
	public Transform Switch;
	Animator anim;
	public GameObject animBody;

	void Start () {
		anim = animBody.GetComponent<Animator>();
	}

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
			Switch.position = transform.TransformPoint (0,0,0);
		} 
	}

	void Update () {
		if(Switch.position == transform.TransformPoint (4,0,0)){
			anim.SetInteger("ArcherAnimNumber",4);
		}
		if(InSwingRange == true && FieldOfView.visibleTargetA.Contains(Attacker)){
			Switch.position = transform.TransformPoint (1,0,0);
		}
		//transform.rotation = Attacker.rotation;
		if(Player == true && InSwingRange == true && Reloading == false && FieldOfView.visibleTargetA.Contains(Attacker) && Switch.position != transform.TransformPoint(4,0,0)){
			StartCoroutine ("Wait");
			//Attacker.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//Instantiate (arrow, transform.TransformPoint(0,0,0.5f), Attacker.rotation);
		}
	}

	IEnumerator Wait ()
	{
		Reloading = true;
		anim.SetInteger("ArcherAnimNumber",1);
		yield return new WaitForSeconds (0.3f);
		if (FieldOfView.visibleTargetA.Contains (Attacker) && Switch.position != transform.TransformPoint (4, 0, 0)) {
			Instantiate (arrow, transform.TransformPoint (0, 0, 0.5f), Attacker.rotation);
			anim.SetInteger("ArcherAnimNumber",2);
			yield return new WaitForSeconds (0.3f);
		} 
		else {
			anim.SetInteger("ArcherAnimNumber",3);
			yield return new WaitForSeconds (0.1f);
		}
		anim.SetInteger("ArcherAnimNumber",0);
		yield return new WaitForSeconds (0.5f);
		Reloading = false;
		yield return null;
	}
}
