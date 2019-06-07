using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	Vector3 curPos;
	Vector3 lastPos;
	public static bool Ismoving = false;
	public bool movingTest = false;

	void Update () {
		curPos = transform.position;
		if(curPos != lastPos){
			Ismoving = true;
			movingTest = true;
		}
		else{
			Ismoving = false;
			movingTest = false;
		}
		lastPos = curPos;
	}
}
