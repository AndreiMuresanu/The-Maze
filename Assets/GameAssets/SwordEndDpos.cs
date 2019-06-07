using UnityEngine;
using System.Collections;

public class SwordEndDpos : MonoBehaviour {

	public static Vector3 SwordEndposD;

	void Update(){
		SwordEndposD = transform.position;
	}
}
