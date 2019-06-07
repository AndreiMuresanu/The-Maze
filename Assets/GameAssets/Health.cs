using UnityEngine;
using System.Collections;
using Image=UnityEngine.UI.Image;

public class Health : MonoBehaviour {

	public float health = 100;
	public float Ohealth = 100;
	//int a;
	//int b;
	//int c;
	public GameObject Attacker;
	int i = 0;
	int o = 0;
	int p = 0;
	bool A = false;
	bool B = false;
	bool C = false;
	public Transform Switch;
	public Transform SwitchA;
	public GameObject HealthBarObject;
	public Image HealthBar;
	bool k = true;
	//AudioSource audio;

	void Start(){
		//a = (Random.Range (0, 2));
		//b = (Random.Range (0, 2));
		//c = (Random.Range (0, 3));
		Ohealth += GameControl.control.Day*5*GameControl.control.Hardness;
		health = Ohealth;
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject.name == "Sword(Clone)" || other.gameObject.name == "Sword 1(Clone)") {
			health -= 15 + PlayerHealth.SwordLevel*5;
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (15f/Ohealth + PlayerHealth.SwordLevel/20f);
		}
		if (other.gameObject.name == "Arrow(Clone)") {
			health -= 15 + PlayerHealth.BowLevel*6;
			other.gameObject.name = "Andrei";
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (15f/Ohealth  + PlayerHealth.BowLevel/16.667f);
		}
		if (other.gameObject.name == "EnergySpell(Clone)"){
			health -= 10 + PlayerHealth.MagicLevel*5;
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (10f/Ohealth  + PlayerHealth.MagicLevel/20f);
		}
		if (other.gameObject.name == "Explosion(Clone)"){
			health -= 5 + PlayerHealth.MagicLevel*5;
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (5f/Ohealth  + PlayerHealth.MagicLevel/20f);
		}
		if (other.gameObject.name == "IceExplosion(Clone)"){
			//Attacker.GetComponent<Renderer>().material.color = Color.yellow;
			health -= 2 + PlayerHealth.MagicLevel*5;
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (2f/Ohealth  + PlayerHealth.MagicLevel/20f);
			SwitchA.position = transform.TransformPoint (3,0,0);
			StartCoroutine("Frozen");
		}
		if (other.gameObject.name == "PoisonSpell(Clone)"){
			//Attacker.GetComponent<Renderer>().material.color = Color.green;
			health -= 3 + PlayerHealth.MagicLevel*5;
			if(k == true){
				HealthBarObject.SetActive(true);
				k = false;
			}
			HealthBar.fillAmount -= (3f/Ohealth  + PlayerHealth.MagicLevel/20f);
			if(A == false){
				StartCoroutine ("PoisonedA");
			}
			else if(B == false){
				StartCoroutine ("PoisonedB");
			}
			else if(C == false){
				StartCoroutine ("PoisonedC");
			}
		}
	}

	void Update(){
		if (health <= 0) {
			//if (a == 0) {
				StartCoroutine ("Wait");
			//}
			/*
			if (a == 1){
				if(b == 0){
					StartCoroutine ("WaitA");
				}
				if(b == 1){
					if(c <= 1){
						StartCoroutine ("WaitB");
					}
					if(c == 2){
						StartCoroutine ("WaitC");
					}
				}
			}
			*/
		}
	}

	IEnumerator Wait(){
		Switch.position = transform.TransformPoint (4,0,0);
		yield return new WaitForSeconds (0.7f);
		PlayerHealth.coins += (Random.Range (7, 14));
		if(Ohealth == 1000 + GameControl.control.Day*5*GameControl.control.Hardness){
			Pause.KeyInHand = true;
		}
		Destroy (Attacker);
	}
	/*
	IEnumerator WaitA(){
		yield return new WaitForSeconds (2);
		Destroy (Attacker);
	}
	IEnumerator WaitB(){
		yield return new WaitForSeconds (2.5f);
		Destroy (Attacker);
	}
	IEnumerator WaitC(){
		yield return new WaitForSeconds (3);
		Destroy (Attacker);
	}
	*/
	IEnumerator Frozen(){
		yield return new WaitForSeconds (3);
		//Attacker.GetComponent<Renderer>().material.color = Color.magenta;
		SwitchA.position = transform.TransformPoint (3,0,0);
	}

	IEnumerator PoisonedA(){
		A = true;
		while(i < 3){
			yield return new WaitForSeconds (1);
			health -= 2 + PlayerHealth.MagicLevel*5;
			HealthBar.fillAmount -= (2f/Ohealth  + PlayerHealth.MagicLevel/20f);
			i++;
		}
		A = false;
		i = 0;
	}

	IEnumerator PoisonedB(){
		B = true;
		while(i < 3){
			yield return new WaitForSeconds (1);
			health -= 2 + PlayerHealth.MagicLevel*5;
			HealthBar.fillAmount -= (2f/Ohealth  + PlayerHealth.MagicLevel/20f);
			o++;
		}
		B = false;
		o = 0;
	}

	IEnumerator PoisonedC(){
		C = true;
		while(i < 3){
			yield return new WaitForSeconds (1);
			health -= 2 + PlayerHealth.MagicLevel*5;
			HealthBar.fillAmount -= (2f/Ohealth  + PlayerHealth.MagicLevel/20f);
			p++;
		}
		C = false;
		p = 0;
	}
}
