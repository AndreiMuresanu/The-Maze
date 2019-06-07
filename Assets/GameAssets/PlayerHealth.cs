using UnityEngine;
using System.Collections;
using Image=UnityEngine.UI.Image;
using Text=UnityEngine.UI.Text;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;

public class PlayerHealth : MonoBehaviour {

	public static float health = 100;
	public static float Ohealth = 100;
	public static bool sheild = false;
	public GameObject Player;
	public Image Healthbar;
	public Image Staminabar;
	public Text TextHealth;
	public Text TextStamina;
	public static float Stamina = 50;
	public static float OStamina = 50;
	bool a = false;
	public static bool CanRoll = true;
	public static int coins = 0;
	public bool CanDie = true;
	public static bool dead;
	public static bool AtShop = false;
	public GameObject ShopButton;
	public Text CoinDisplay;
	public static int SwordLevel = 0;
	public static int BowLevel = 0;
	public static int MagicLevel = 0;
	AudioSource audio;
	public AudioClip OO;
	public AudioClip AW;
	public GameObject ExitMenu;
	public GameObject WinScreen;
	public Text WinScreenText;
	public GameObject DeathScreen;
	public Text DeathScreenText;
	bool SeenHighscoreTest = false;


	public void SheildButtonPress(){
		if (Sword.SwordIsAlive == false && Stamina > 0 && Pause.paused == false && (Pause.SwordEquiped == true || Pause.SwordEquipedS == true && SwordSwing.CastingSpell == false)){
			//Player.GetComponent<Renderer>().material.color = Color.green;
			PlayerAnimationManager.CurrentAnimation = 4;
			sheild = true;
		}
	}

	public void SheildButtonPressUp(){
			//Player.GetComponent<Renderer>().material.color = Color.white;
			PlayerAnimationManager.CurrentAnimation = 0;
			sheild = false;
	}

	public void DashButtonPress (){
		if (Stamina >= 25 && Pause.paused == false) {
			Stamina -= 25;
			StartCoroutine ("StaminaCounterUp");
		}
	}

	void Start(){
		audio = GetComponent<AudioSource>();
		Ohealth = 600/GameControl.control.Hardness;
		health = Ohealth;
		//TextHealth = GameObject.Find ("HPManaBar").transform.FindChild ("HP").FindChild("Text").GetComponent<Text> ();
		//Healthbar = GameObject.Find ("HPManaBar").transform.FindChild ("HP").GetComponent<Image> ();
		//TextStamina = GameObject.Find ("HPManaBar").transform.FindChild ("Stamina").FindChild("Text").GetComponent<Text> ();
		//Staminabar = GameObject.Find ("HPManaBar").transform.FindChild ("Stamina").GetComponent<Image> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (dead == false && CanDie == true) {
			if (other.gameObject.name == "ASword") {
				//Debug.Log ("Hit by sword");
				if (sheild == false && Controller1.rolling == false) {
					health -= GameControl.control.Day*2*GameControl.control.Hardness;
					audio.clip = OO;
					audio.Play();
				}
			}
			if (other.gameObject.name == "AArrow(Clone)") {
				if (sheild == false && Controller1.rolling == false) {
					health -= GameControl.control.Day*2*GameControl.control.Hardness;
					audio.clip = AW;
					audio.Play();
				}
			}
		}
		if(other.gameObject.name == "ShopAura"){
			AtShop = true;
		}
		if(other.gameObject.name == "ExitDoor(Clone)" && Pause.KeyInHand == true){
			//GridScript.AreYouSureExitMenu = true;
			Pause.paused = true;
			Debug.Log("Exit Door Should Work");
			ExitMenu.SetActive(true);
		}
	}

	public void WantToStayPress (){
		ExitMenu.SetActive(false);
		Pause.paused = false;
	}

	public void WantToLeavePress (){
		ExitMenu.SetActive(false);
		GameControl.control.Day = 1;
		coins = 0;
		MagicLevel = 0;
		SwordLevel = 0;
		BowLevel = 0;
		Pause.NumberOfBagOfPoos = 0;
		Pause.NumberOfHealthPotions = 0;
		Pause.KeyInHand = false;
		Ohealth = 100;
		OStamina = 50;
		GameControl.control.Save();
		WinScreenText.text = " After " + GameControl.control.Day.ToString() + " days you have escaped the maze, but the king was already dead and the new king did not want to give up his position. Better luck next time.";
		WinScreen.SetActive(true);
	}

	public void WinScreenClosePress(){
		SceneManager.LoadScene("Menu");
	}

	void OnTriggerExit (Collider other){
		if(other.gameObject.name == "ShopAura"){
			AtShop = false;
		}
	}

	void Update ()
	{
		if (Pause.SwordEquiped == true && Pause.SwordEquipedS == false) {
			PlayerAnimationManager.HowManySwords = 1;
		}
		if (Pause.SwordEquipedS == true && Pause.SwordEquiped == false) {
			PlayerAnimationManager.HowManySwords = 0;
		}
		if (Pause.SwordEquiped == true && Pause.SwordEquipedS == true) {
			PlayerAnimationManager.HowManySwords = 2;
		}
		if (Pause.SwordEquiped == false && Pause.SwordEquipedS == false) {
			PlayerAnimationManager.HowManySwords = 3;
		}
		if (AtShop == true) {
			ShopButton.SetActive (true);
		} else {
			ShopButton.SetActive (false);
		}
		if (Stamina >= 25) {
			CanRoll = true;
		}
		if (Stamina < 25) {
			CanRoll = false;
		}
		//the code below is for pc only
		if (Input.GetButtonDown ("Fire1") && Sword.SwordIsAlive == false && Stamina > 0 && Pause.paused == false && (Pause.SwordEquiped == true || Pause.SwordEquipedS == true && SwordSwing.CastingSpell == false)){
			//Player.GetComponent<Renderer>().material.color = Color.green;
			PlayerAnimationManager.CurrentAnimation = 4;
			sheild = true;
		}
		if (Input.GetButtonUp ("Fire1") || Controller1.rolling == true || Stamina == 0){
			//Player.GetComponent<Renderer>().material.color = Color.white;
			PlayerAnimationManager.CurrentAnimation = 0;
			sheild = false;
		}
		//up to here
		if (Input.GetKeyDown ("f") && Stamina >= 25 && Pause.paused == false) {
			Stamina -= 25;
			StartCoroutine ("StaminaCounterUp");
		}
		if (sheild == true && a == false) {
			a = true;
			StopCoroutine ("StaminaCounterUp");
			StartCoroutine ("StaminaCounterDown");
		}
		if (sheild == false && a == true) {
			a = false;
			StartCoroutine ("StaminaCounterUp");
			StopCoroutine ("StaminaCounterDown");
		}
		if (health <= 0) {
			if (SeenHighscoreTest == false) {
					dead = true;
				if (GameControl.control.Day * GameControl.control.Hardness > GameControl.control.NewScoreA * GameControl.control.ScoreHardnessA) {
					GameControl.control.NewScoreE = GameControl.control.NewScoreD;
					GameControl.control.NewScoreD = GameControl.control.NewScoreC;
					GameControl.control.NewScoreC = GameControl.control.NewScoreB;
					GameControl.control.NewScoreB = GameControl.control.NewScoreA;
					GameControl.control.NewScoreA = GameControl.control.Day;
					GameControl.control.ScoreHardnessE = GameControl.control.ScoreHardnessD;
					GameControl.control.ScoreHardnessD = GameControl.control.ScoreHardnessC;
					GameControl.control.ScoreHardnessC = GameControl.control.ScoreHardnessB;
					GameControl.control.ScoreHardnessB = GameControl.control.ScoreHardnessA;
					GameControl.control.ScoreHardnessA = GameControl.control.Hardness;
				} else if (GameControl.control.Day * GameControl.control.Hardness > GameControl.control.NewScoreB * GameControl.control.ScoreHardnessB) {
					GameControl.control.NewScoreE = GameControl.control.NewScoreD;
					GameControl.control.NewScoreD = GameControl.control.NewScoreC;
					GameControl.control.NewScoreC = GameControl.control.NewScoreB;
					GameControl.control.NewScoreB = GameControl.control.Day;
					GameControl.control.ScoreHardnessE = GameControl.control.ScoreHardnessD;
					GameControl.control.ScoreHardnessD = GameControl.control.ScoreHardnessC;
					GameControl.control.ScoreHardnessC = GameControl.control.ScoreHardnessB;
					GameControl.control.ScoreHardnessB = GameControl.control.Hardness;
				} else if (GameControl.control.Day * GameControl.control.Hardness > GameControl.control.NewScoreC * GameControl.control.ScoreHardnessC) {
					GameControl.control.NewScoreE = GameControl.control.NewScoreD;
					GameControl.control.NewScoreD = GameControl.control.NewScoreC;
					GameControl.control.NewScoreC = GameControl.control.Day;
					GameControl.control.ScoreHardnessE = GameControl.control.ScoreHardnessD;
					GameControl.control.ScoreHardnessD = GameControl.control.ScoreHardnessC;
					GameControl.control.ScoreHardnessC = GameControl.control.Hardness;
				} else if (GameControl.control.Day * GameControl.control.Hardness > GameControl.control.NewScoreD * GameControl.control.ScoreHardnessD) {
					GameControl.control.NewScoreE = GameControl.control.NewScoreD;
					GameControl.control.NewScoreD = GameControl.control.Day;
					GameControl.control.ScoreHardnessE = GameControl.control.ScoreHardnessD;
					GameControl.control.ScoreHardnessD = GameControl.control.Hardness;
				} else if (GameControl.control.Day * GameControl.control.Hardness > GameControl.control.NewScoreE * GameControl.control.ScoreHardnessE) {
					GameControl.control.NewScoreE = GameControl.control.Day;
					GameControl.control.ScoreHardnessE = GameControl.control.Hardness;
				}
				Debug.Log ("D " + GameControl.control.NewScoreA.ToString () + ", " + GameControl.control.NewScoreB.ToString () + ", " + GameControl.control.NewScoreC.ToString () + ", " + GameControl.control.NewScoreD.ToString () + ", " + GameControl.control.NewScoreE.ToString ());
				Debug.Log ("H " + GameControl.control.ScoreHardnessA.ToString () + ", " + GameControl.control.ScoreHardnessB.ToString () + ", " + GameControl.control.ScoreHardnessC.ToString () + ", " + GameControl.control.ScoreHardnessD.ToString () + ", " + GameControl.control.ScoreHardnessE.ToString ());
				SeenHighscoreTest = true;
				if(GameControl.control.Day == 1){
					DeathScreenText.text = "Really you only survived one day? Seems your not a very good hero.";
				}
				else{
					DeathScreenText.text = "After " + GameControl.control.Day.ToString() + " days you have been killed. The king died with no heir and the whole kingdom fell into chaos. Good job.";
				}
				GameControl.control.Day = 1;
				coins = 0;
				MagicLevel = 0;
				SwordLevel = 0;
				BowLevel = 0;
				Pause.NumberOfBagOfPoos = 0;
				Pause.NumberOfHealthPotions = 0;
				Pause.KeyInHand = false;
				Ohealth = 100;
				OStamina = 50;
				GameControl.control.Save();
				Pause.paused = true;
				//ONLY for android
				/*if (Advertisement.IsReady()){
	      			Advertisement.Show();
	      			//Debug.Log("ADShouldHaveShown");
	    		}*/
				DeathScreen.SetActive(true);
			}
		}
		CoinDisplay.text = "Coins " + coins.ToString();
		Healthbar.fillAmount = health / Ohealth;
		TextHealth.text = "Health " + health.ToString() + "/" + Ohealth.ToString();
		Staminabar.fillAmount = Stamina / OStamina;
		TextStamina.text = "Stamina " + Stamina.ToString() + "/" + OStamina.ToString();

	}

	IEnumerator StaminaCounterDown(){
		while (Stamina > 0) {
			yield return new WaitForSeconds (0.025f);
			Stamina -= 1;
		}
	}

	IEnumerator StaminaCounterUp(){
		while (Stamina < OStamina) {
			Stamina += 1;
			yield return new WaitForSeconds (0.05f);
		}
		/*
		while (health < Ohealth) {
			health += 1;
			yield return new WaitForSeconds (0.2f);
		}
		*/
	}

	public void GainingCoins(){
		coins += 10;
	}
}
