using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

	Animator anim;
	public static int CurrentAnimation = 0;
	public static int HowManySwords = 0;
	public static int WhichSpellIsActive = 0;
	public static int WhichSwordSwing = 0;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(CurrentAnimation == 0){
			anim.SetInteger("AnimationNumber",0);
		}
		if(CurrentAnimation == 1){
			anim.SetInteger("AnimationNumber",1);
			//Debug.Log("Running");
		}
		if(CurrentAnimation == 2){
			anim.SetInteger("AnimationNumber",2);
		}
		if(CurrentAnimation == 3){
			anim.SetInteger("AnimationNumber",3);
		}
		if(CurrentAnimation == 4){
			anim.SetInteger("AnimationNumber",4);
		}
		if(CurrentAnimation == 5){
			anim.SetInteger("AnimationNumber",5);
		}
		if(CurrentAnimation == 6){
			anim.SetInteger("AnimationNumber",6);
		}
		if(CurrentAnimation == 7){
			anim.SetInteger("AnimationNumber",7);
		}
		if(CurrentAnimation == 8){
			anim.SetInteger("AnimationNumber",8);
			//Debug.Log("Dashing");
		}


		if(HowManySwords == 3){
			anim.SetInteger("HowManySwords",3);
		}
		if(HowManySwords == 2){
			anim.SetInteger("HowManySwords",2);
		}
		if(HowManySwords == 1){
			anim.SetInteger("HowManySwords",1);
		}
		if(HowManySwords == 0){
			anim.SetInteger("HowManySwords",0);
		}


		if(WhichSwordSwing == 0){
			anim.SetInteger("WhichSwordSwing",0);
		}
		if(WhichSwordSwing == 1){
			anim.SetInteger("WhichSwordSwing",1);
		}
		if(WhichSwordSwing == 2){
			anim.SetInteger("WhichSwordSwing",2);
		}


		if(WhichSpellIsActive == 0){
			anim.SetInteger("WhichSpellIsActive",0);
		}
		if(WhichSpellIsActive == 1){
			anim.SetInteger("WhichSpellIsActive",1);
		}
		if(WhichSpellIsActive == 2){
			anim.SetInteger("WhichSpellIsActive",2);
		}
		if(WhichSpellIsActive == 3){
			anim.SetInteger("WhichSpellIsActive",3);
		}
	}
}
