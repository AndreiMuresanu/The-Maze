using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {

	public Transform Player;
	public bool testing = false;

	void Update () {
		transform.position = new Vector3(Player.position.x,Player.position.y + 3, Player.position.z); 
	}
}
