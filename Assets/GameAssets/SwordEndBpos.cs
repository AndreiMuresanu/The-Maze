using UnityEngine;
using System.Collections;

public class SwordEndBpos : MonoBehaviour {

	public static Vector3 SwordEndposB;

	void Update(){
		SwordEndposB = transform.position;
	}
}
