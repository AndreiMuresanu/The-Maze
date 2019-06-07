using UnityEngine;
using System.Collections;

public class AttackerSpawnTest : MonoBehaviour {

	public GameObject Attacker;

	void Update () {
		if(Input.GetKeyDown("g")){
			//Instantiate (Attacker, new Vector3 (60,5.2f,60), Quaternion.identity);
			Instantiate (Attacker, new Vector3 (0,0,0), Controller1.playerro);
		}
	}
}
