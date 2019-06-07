using UnityEngine;
using System.Collections;

public class AttackerSwordSwing : MonoBehaviour {

	bool InSwingRange = false;
	public GameObject sword;
	Vector3 thePositionS;
	Vector3 thePositionSA;
	Vector3 thePositionSB;
	Vector3 thePositionSC;
	int Scombo = 2;
	int i = 0;
	int movespeed = 20;
	bool SwingOver = true;
	Vector3 SwordEndposA;
	Vector3 SwordEndposB;
	Vector3 SwordEndposC;



	void OnTriggerEnter (Collider other){
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
		//if(InSwingRange == true){
		//	Debug.Log ("Swinging Sword");
		//}
		thePositionS = transform.TransformPoint(1,0,1.5f);
		thePositionSA = transform.TransformPoint(-1,0,1.5f);
		thePositionSB = transform.TransformPoint(0.5f,0,0.5f);
		SwordEndposA = transform.TransformPoint(-1.5f,0,1);
		SwordEndposB = transform.TransformPoint(1.5f,0,1);
		SwordEndposC = transform.TransformPoint(0.3f,0,1.7f);


		if (InSwingRange == true && SwingOver == true) {
			Debug.Log ("Swinging Sword");
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
		/*if(Scombo == 0 && SwingOver == false){
			sword.transform.position = Vector3.Lerp (transform.position, SwordEndposA, movespeed * Time.deltaTime);
			sword.transform.Rotate (Vector3.down * Time.deltaTime * 180);	
		}
		if(Scombo == 1 && SwingOver == false){
			sword.transform.position = Vector3.Lerp (transform.position, SwordEndposB, movespeed * Time.deltaTime);
			sword.transform.Rotate (Vector3.down * Time.deltaTime * -180);
		}
		if(Scombo == 2 && SwingOver == false){
			sword.transform.position = Vector3.Lerp (transform.position, SwordEndposC, movespeed * Time.deltaTime);
			sword.transform.Rotate (Vector3.down * Time.deltaTime * 180);
		}*/
	}

	void SingleSwordClass(){
		if (Scombo == 3) {
			Scombo = 0;
		}
		if(Scombo == 0){
			SwingOver = false;
			sword.transform.position = thePositionS;
			//sword.transform.rotation = transform.rotation;
			sword.SetActive (true);
			//Instantiate (sword, thePositionS, transform.rotation);
			StartCoroutine ("Wait");
		}
		if(Scombo == 1){
			SwingOver = false;
			sword.transform.position = thePositionSA;
			//sword.transform.rotation = transform.rotation;
			sword.SetActive (true);
			//Instantiate (sword, thePositionSA, transform.rotation);
			StartCoroutine ("Wait");
		}
		if(Scombo == 2){
			SwingOver = false;
			sword.transform.position = thePositionSB;
			//sword.transform.rotation = transform.rotation;
			sword.SetActive (true);
			//Instantiate (sword, thePositionSB, transform.rotation);
			StartCoroutine ("Wait");
		}
	}


	IEnumerator ComboTimeCounter(){
		while(i < 1)
		{
			yield return new WaitForSeconds(0.5f);
			i++;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.4f);
		sword.SetActive (false);
		//sword.transform.rotation = transform.rotation;
		//sword.transform.position = new Vector3(0, -2, 0);
		SwingOver = true;
		yield return null;
	}
}
