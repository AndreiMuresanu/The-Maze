using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour {

	public Transform sword;
	public Transform swordA;
	Vector3 thePositionA;
	Vector3 thePositionS;
	Vector3 thePositionSA;
	Vector3 thePositionSB;
	Vector3 thePositionSC;
	public static int Scombo = 2;
	public static int SDcombo = 2;
	int i = 0;
	public Transform arrow;
	//public static bool SingleSword = false;
	//public static bool DualSword = false;
	public GameObject Spell;
	public GameObject SpellF;
	public GameObject SpellI;
	public GameObject SpellP;
	Quaternion asd;
	Quaternion asdf;
	public static bool FireingBow = false;
	public static bool CastingSpell = false;
	public bool PrimaryButtonPress = false;
	public bool SecondaryButtonPress = false;


	public void PrimaryHandPress(){
		PrimaryButtonPress = true;
		StartCoroutine("ButtonClickTime");
	}

	public void SecondaryHandPress(){
		SecondaryButtonPress = true;
		StartCoroutine("ButtonClickTime");
	}

	void Update ()
	{
		thePositionS = transform.TransformPoint (1, 0, 1.5f);
		thePositionSA = transform.TransformPoint (-1, 0, 1.5f);
		thePositionSB = transform.TransformPoint (0.5f, 0, 0.5f);
		thePositionSC = transform.TransformPoint (-0.5f, 0, 0.5f);
		thePositionA = transform.TransformPoint (0, 0, 2);
		//if (Input.GetKeyDown ("t")) {
		//Sword.TwoSwordsInHand = !Sword.TwoSwordsInHand;
		//}
		if (FireingBow == true) {
			PlayerAnimationManager.CurrentAnimation = 2;
		}
		if (PlayerHealth.dead == false) {
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.BowEquiped == true) {
				if (FireingBow == false) {
					StartCoroutine ("BowFireing");
				}
			}
			if ((Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true) && Sword.AntiSpam == false && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SwordEquiped == true && Pause.SwordEquipedS == false && CastingSpell == false) {
				//SingleSword = true;
				Sword.TwoSwordsInHand = false;
				if (i < 1) {
					StopCoroutine ("ComboTimeCounter"); 
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo++;
					SingleSwordClass ();
				}
				if (i == 1) {
					StopCoroutine ("ComboTimeCounter");
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo = 0;
					SingleSwordClass ();
				}
			}
			if ((Input.GetButtonDown ("Fire3") || SecondaryButtonPress == true) && Sword.AntiSpam == false && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SwordEquipedS == true && Pause.SwordEquiped == false && CastingSpell == false) {
				//SingleSword = true;
				Sword.TwoSwordsInHand = false;
				if (i < 1) {
					StopCoroutine ("ComboTimeCounter"); 
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo++;
					LeftSwordClass ();
				}
				if (i == 1) {
					StopCoroutine ("ComboTimeCounter");
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					Scombo = 0;
					LeftSwordClass ();
				}
			}
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && Sword.AntiSpam == false && Controller1.rolling == false && PlayerHealth.sheild == false && Pause.paused == false && Pause.SwordEquiped == true && Pause.SwordEquipedS == true && CastingSpell == false) {
				//DualSword = true;
				Sword.TwoSwordsInHand = true;
				if (i < 1) {
					StopCoroutine ("ComboTimeCounter"); 
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					SDcombo++;
					DualSwordClass ();
				}
				if (i == 1) {
					StopCoroutine ("ComboTimeCounter");
					i = 0;
					StartCoroutine ("ComboTimeCounter");
					SDcombo = 0;
					DualSwordClass ();
				}
			}
			if ((Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquiped == true && Pause.SpellEquipedS == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 3;
					PlayerAnimationManager.WhichSpellIsActive = 0;
					StartCoroutine ("SpellCastTime");
				}
				/*if (a == true) {
					Instantiate (Spell, thePositionSB, Controller1.playerro);
					a = false;
				}*/
			}
			if ((Input.GetButtonDown ("Fire3") || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedS == true && Pause.SpellEquiped == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 5;
					PlayerAnimationManager.WhichSpellIsActive = 0;
					StartCoroutine ("SpellSCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SpellEquiped == true && Pause.SpellEquipedS == true) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 6;
					PlayerAnimationManager.WhichSpellIsActive = 0;
					StartCoroutine ("SpellDCastTime");
				}
			}

			if ((Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedF == true && Pause.SpellEquipedFS == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 3;
					PlayerAnimationManager.WhichSpellIsActive = 1;
					StartCoroutine ("SpellCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedFS == true && Pause.SpellEquipedF == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 5;
					PlayerAnimationManager.WhichSpellIsActive = 1;
					StartCoroutine ("SpellSCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SpellEquipedF == true && Pause.SpellEquipedFS == true) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 6;
					PlayerAnimationManager.WhichSpellIsActive = 1;
					StartCoroutine ("SpellDCastTime");
				}
			}

			if ((Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedI == true && Pause.SpellEquipedIS == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 3;
					PlayerAnimationManager.WhichSpellIsActive = 2;
					StartCoroutine ("SpellCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedIS == true && Pause.SpellEquipedI == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 5;
					PlayerAnimationManager.WhichSpellIsActive = 2;
					StartCoroutine ("SpellSCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SpellEquipedI == true && Pause.SpellEquipedIS == true) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 6;
					PlayerAnimationManager.WhichSpellIsActive = 2;
					StartCoroutine ("SpellDCastTime");
				}
			}

			asd = Controller1.playerro * Quaternion.Euler (0, 20, 0);
			asdf = Controller1.playerro * Quaternion.Euler (0, -20, 0);
			if ((Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedP == true && Pause.SpellEquipedPS == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 3;
					PlayerAnimationManager.WhichSpellIsActive = 3;
					StartCoroutine ("SpellCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Pause.paused == false && Controller1.rolling == false && Pause.SpellEquipedPS == true && Pause.SpellEquipedP == false) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 5;
					PlayerAnimationManager.WhichSpellIsActive = 3;
					StartCoroutine ("SpellSCastTime");
				}
			}
			if ((Input.GetButtonDown ("Fire3") || Input.GetButtonDown ("Fire2") || PrimaryButtonPress == true || SecondaryButtonPress == true) && PlayerHealth.sheild == false && Controller1.rolling == false && Pause.paused == false && Pause.SpellEquipedP == true && Pause.SpellEquipedPS == true) {
				if (CastingSpell == false) {
					CastingSpell = true;
					PlayerAnimationManager.CurrentAnimation = 6;
					PlayerAnimationManager.WhichSpellIsActive = 3;
					StartCoroutine ("SpellDCastTime");
				}
			}
		}
	}

	void SingleSwordClass(){
		if (Scombo == 3) {
			Scombo = 0;
		}
		if(Scombo == 0){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 1;
			PlayerAnimationManager.WhichSwordSwing = 0;
			CastingSpell = true;
			Instantiate (sword, thePositionS, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
		if(Scombo == 1){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 1;
			PlayerAnimationManager.WhichSwordSwing = 1;
			CastingSpell = true;
			Instantiate (sword, thePositionSA, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
		if(Scombo == 2){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 1;
			PlayerAnimationManager.WhichSwordSwing = 2;
			CastingSpell = true;
			Instantiate (sword, thePositionSB, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
	}

	void DualSwordClass(){
		if (SDcombo == 3) {
			SDcombo = 0;
		}
		if(SDcombo == 0){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 2;
			PlayerAnimationManager.WhichSwordSwing = 0;
			CastingSpell = true;
			Instantiate (sword, thePositionS, Controller1.playerro);
			Instantiate (swordA, thePositionSA, Controller1.playerro);
			StartCoroutine ("SwordSwingTimeD");
		}
		if(SDcombo == 1){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 2;
			PlayerAnimationManager.WhichSwordSwing = 1;
			CastingSpell = true;
			Instantiate (swordA, thePositionS, Controller1.playerro);
			Instantiate (sword, thePositionSA, Controller1.playerro);
			StartCoroutine ("SwordSwingTimeD");
		}
		if(SDcombo == 2){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 2;
			PlayerAnimationManager.WhichSwordSwing = 2;
			CastingSpell = true;
			Instantiate (sword, thePositionSB, Controller1.playerro);
			Instantiate (swordA, thePositionSC, Controller1.playerro);
			StartCoroutine ("SwordSwingTimeD");
		}
	}

	void LeftSwordClass(){
		if (Scombo == 3) {
			Scombo = 0;
		}
		if(Scombo == 0){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 0;
			PlayerAnimationManager.WhichSwordSwing = 0;
			CastingSpell = true;
			Instantiate (swordA, thePositionSA, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
		if(Scombo == 1){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 0;
			PlayerAnimationManager.WhichSwordSwing = 1;
			CastingSpell = true;
			Instantiate (swordA, thePositionS, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
		if(Scombo == 2){
			PlayerAnimationManager.CurrentAnimation = 7;
			PlayerAnimationManager.HowManySwords = 0;
			PlayerAnimationManager.WhichSwordSwing = 2;
			CastingSpell = true;
			Instantiate (swordA, thePositionSC, Controller1.playerro);
			StartCoroutine ("SwordSwingTime");
		}
	}

	IEnumerator ComboTimeCounter(){
		while(i < 1)
			{
				yield return new WaitForSeconds(0.5f);
				i++;
			}
	}

	IEnumerator BowFireing(){
		FireingBow = true;
		yield return new WaitForSeconds(0.6f);
		Instantiate (arrow, thePositionA, Controller1.playerro);
		//PlayerAnimationManager.CurrentAnimation = 0;
		FireingBow = false;
		//yield return null;
	}

	IEnumerator SwordSwingTime(){
		yield return new WaitForSeconds(0.29f);
		CastingSpell = false;
	}

	IEnumerator SwordSwingTimeD(){
		yield return new WaitForSeconds(0.29f);
		CastingSpell = false;
	}

	IEnumerator SpellCastTime (){
		yield return new WaitForSeconds (0.85f);
		if (PlayerAnimationManager.WhichSpellIsActive == 0) {
			Instantiate (Spell, thePositionSB, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 1) {
			Instantiate (SpellF, thePositionSB, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 2) {
			Instantiate (SpellI, thePositionSB, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 3) {
			Instantiate (SpellP, thePositionSB, asd);
			Instantiate (SpellP, thePositionSB, Controller1.playerro);
			Instantiate (SpellP, thePositionSB, asdf);
		}
		yield return new WaitForSeconds(0.1f);
		CastingSpell = false;
	}

	IEnumerator SpellSCastTime (){
		yield return new WaitForSeconds (0.85f);
		if (PlayerAnimationManager.WhichSpellIsActive == 0) {
			Instantiate (Spell, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 1) {
			Instantiate (SpellF, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 2) {
			Instantiate (SpellI, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 3) {
			Instantiate (SpellP, thePositionSC, asd);
			Instantiate (SpellP, thePositionSC, Controller1.playerro);
			Instantiate (SpellP, thePositionSC, asdf);
		}
		yield return new WaitForSeconds(0.1f);
		CastingSpell = false;
	}

	IEnumerator SpellDCastTime (){
		yield return new WaitForSeconds (0.85f);
		if (PlayerAnimationManager.WhichSpellIsActive == 0) {
			Instantiate (Spell, thePositionSB, Controller1.playerro);
			Instantiate (Spell, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 1) {
			Instantiate (SpellF, thePositionSB, Controller1.playerro);
			Instantiate (SpellF, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 2) {
			Instantiate (SpellI, thePositionSB, Controller1.playerro);
			Instantiate (SpellI, thePositionSC, Controller1.playerro);
		}
		if (PlayerAnimationManager.WhichSpellIsActive == 3) {
			Instantiate (SpellP, thePositionSB, asd);
			Instantiate (SpellP, thePositionSB, Controller1.playerro);
			Instantiate (SpellP, thePositionSB, asdf);
			Instantiate (SpellP, thePositionSC, asd);
			Instantiate (SpellP, thePositionSC, Controller1.playerro);
			Instantiate (SpellP, thePositionSC, asdf);
		}
		yield return new WaitForSeconds(0.1f);
		CastingSpell = false;
	}

	IEnumerator ButtonClickTime(){
		yield return new WaitForSeconds(0.2f);
		PrimaryButtonPress = false;
		SecondaryButtonPress = false;
	}
}
