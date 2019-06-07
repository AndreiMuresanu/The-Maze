using UnityEngine;
using System.Collections;

public class SwordGhostAnimationManager : MonoBehaviour {

	Animator anim;
	public Transform Switch;
	public Transform Switch1;
	public Transform Body;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (0,0,0)){
			anim.SetInteger("CurrentAnimation", 1);
		}
		if(Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (1,0,0)){
			anim.SetInteger("CurrentAnimation", 1);
		}
		if(Switch1.position == Body.TransformPoint (1,0,0) && Switch.position == Body.TransformPoint (2,0,0)){
			anim.SetInteger("CurrentAnimation", 1);
		}
		if(Switch1.position == Body.TransformPoint (0,0,0)){
			anim.SetInteger("CurrentAnimation", 0);
		}
		if(Switch.position == Body.TransformPoint (4,0,0)){
			anim.SetInteger("CurrentAnimation", 4);
		}
	}
}
