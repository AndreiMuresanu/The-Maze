using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAnimationManager : MonoBehaviour {

	Animator anim;
	public static int MinotaurCurrentAnimation = 0;
	public Transform Switch1;
	public Transform Switch;
	public Transform Body;
	public Transform RealBody;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update (){
		/*if (Switch1.position == Body.TransformPoint (0,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 0);
		}
		if (MinotaurCurrentAnimation == 1) {
			anim.SetInteger ("MinotaurCurrentAnimation", 1);
		}
		if (Switch1.position == Body.TransformPoint (1,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 2);
		}*/
		if (Switch1.position == Body.TransformPoint (0,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 0);
		}
		if (Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (0,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 2);
		}
		if (Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (1,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 3);
		}
		if (Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (2,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 4);
		}
		if(RealBody.GetComponent<Rigidbody>().velocity != Vector3.zero && (Switch1.position != Body.TransformPoint (1,0,0)
		 && Switch.position != Body.TransformPoint (0,0,0)) || (Switch1.position != Body.TransformPoint (1,0,0)
		  && Switch.position != Body.TransformPoint (1,0,0))){
			anim.SetInteger("MinotaurCurrentAnimation", 1);
		}
		if (Switch.position == Body.TransformPoint (4,0,0)) {
			anim.SetInteger ("MinotaurCurrentAnimation", 5);
		}
	}
}
