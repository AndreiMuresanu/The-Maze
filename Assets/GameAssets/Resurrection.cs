using UnityEngine;
using System.Collections;

public class Resurrection : MonoBehaviour {

	public GameObject Player;

	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			Instantiate (Player,new Vector3(0,0,0),Quaternion.identity);
		}
	}
}
