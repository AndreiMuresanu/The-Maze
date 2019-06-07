using UnityEngine;
using System.Collections;

public class VendorAnimation : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(PlayerHealth.AtShop == false){
			anim.SetBool("PlayerClose", false);
		}
		if(PlayerHealth.AtShop == true){
			anim.SetBool("PlayerClose", true);
		}
	}
}
