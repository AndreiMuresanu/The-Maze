using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	int movespeed = 50;
	public bool Hit = false;
	float ArrowHitRo;
	float OriginalRo;
	GameObject ThingThatWasHit;
	float AttackerORo;
	float Difference;
	bool CoroutineStarted = false;
	float CurRo;
	float LastRo;
	GameObject HitAttacker;
	//Vector3 ArrowColPos;
	//Vector3 AttackerColPos;
	//Vector3 ArrowPos;


	void Start(){
		//OriginalRo = transform.rotation;
		OriginalRo = transform.eulerAngles.y;
	}

	void Update() {
		if(ThingThatWasHit == null && Hit == true){
			Destroy (gameObject);
		}
			//ArrowHitRo = new Quaternion (.AttackerRo.x, Unit1.AttackerRo.y - OriginalRo.y, Unit1.AttackerRo.z, Unit1.AttackerRo.w);

		if (Hit == false) {
			transform.Translate (Vector3.forward * Time.deltaTime * movespeed);
		}
		if (Hit == true && ThingThatWasHit != null){
			//ArrowColPos = Unit1.AttackerPos - ArrowColPos;
			//transform.position = Unit1.AttackerPos + ArrowColPos;
			//transform.position = Unit1.AttackerPos;
			transform.position = HitAttacker.transform.position;
			CurRo = ThingThatWasHit.transform.eulerAngles.y; 
			if (LastRo != CurRo){
				transform.eulerAngles = new Vector3(0, CurRo + Difference, 0);
			}
			LastRo = CurRo;
			//transform.rotation = ArrowHitRo;
			//transform.rotation = new Quaternion(0, Unit1.AttackerRo.y + Difference.y, 0, 0);
			//transform.rotation.y = CurRo.y + Difference.y;
		}
		if (CoroutineStarted == false){
			StartCoroutine ("Wait");
		}
	}

	void OnTriggerEnter (Collider other){
		//Debug.Log ("Ball has entered!");
		if (other.gameObject.name == "AttackerBody") {
			//ArrowColPos = transform.position;
			//AttackerColPos = other.gameObject.transform.position;
			//AttackerORo = Unit1.AttackerRo;
			HitAttacker = other.gameObject;
			AttackerORo = other.gameObject.transform.eulerAngles.y;
			//Difference.y = OriginalRo.y - AttackerORo.y;
			Difference = OriginalRo - AttackerORo;
			ThingThatWasHit = other.gameObject;
			Hit = true;
			//Destroy (other.gameObject);
		}
	}

	IEnumerator Wait(){
		CoroutineStarted = true;
		yield return new WaitForSeconds (0.5f);
		if (Hit == false) {
			Destroy (gameObject);
		}
	}
}
