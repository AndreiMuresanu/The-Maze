using UnityEngine;
using System.Collections;
//using Text=UnityEngine.UI.Text;
//using UnityEngine.Advertisements;
//using Image=UnityEngine.UI.Image;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public static bool paused = true;
	public GameObject menu;
	bool PrimarySelect = false;
	bool SecondarySelect = false;
	public static bool SwordEquiped = false;
	public static bool BowEquiped = false;
	public static bool SpellEquiped = false;
	public static bool SpellEquipedF = false;
	public static bool SpellEquipedI = false;
	public static bool SpellEquipedP = false;
	public static bool SwordEquipedS = false;
	public static bool SpellEquipedS = false;
	public static bool SpellEquipedFS = false;
	public static bool SpellEquipedIS = false;
	public static bool SpellEquipedPS = false;
	public static int NumberOfHealthPotions = 0;
	public Text NumberOfHealthPotionsText;
	public GameObject Shop;
	public Text SwordLevelText;
	public Text BowLevelText;
	public Text MagicLevelText;
	public Sprite PrimarySelectImage;
	public Sprite SecondarySelectImage;
	public Sprite BowImage;
	public Sprite SwordImage;
	public Sprite SpellImage;
	public Sprite SpellFImage;
	public Sprite SpellIImage;
	public Sprite SpellPImage;
	public Button PrimaryActive;
	public Button SecondaryActive;
	public Button Key;
	public Sprite KeyImage;
	public static bool KeyInHand = false;
	public Button BagOfPoo;
	public Sprite BagOfPooImage;
	public static int NumberOfBagOfPoos = 0;
	public Text NumberOfBagOfPoosText;
	public Button PrimaryButton;
	public Button SecondaryButton;
	public GameObject Block;
	public GameObject Dash;
	public GameObject JoyStick;
	public GameObject Primary;
	public GameObject Secondary;
	public GameObject InventoryButton;


	void Awake(){
		NumberOfHealthPotionsText.text = "Health Potion " + NumberOfHealthPotions.ToString() + "x";
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			paused = !paused;
		}
		if(paused == true){
			Time.timeScale = 0;
		}
		if(paused == false){
			Time.timeScale = 1;
		}

		if(SwordEquiped == true && SwordEquipedS == false){
			PlayerAnimationManager.HowManySwords = 1;
		}
		if(SwordEquipedS == true && SwordEquiped == false){
			PlayerAnimationManager.HowManySwords = 0;
		}
		if(SwordEquiped == true && SwordEquipedS == true){
			PlayerAnimationManager.HowManySwords = 2;
		}
		if(SwordEquiped == false && SwordEquipedS == false){
			PlayerAnimationManager.HowManySwords = 3;
		}


		if(KeyInHand == true){
			Key.image.sprite = KeyImage;
		}
		if(NumberOfBagOfPoos > 0){
			BagOfPoo.image.sprite = BagOfPooImage;
		}
		//if( == true){
		//	PlayerAnimationManager.CurrentAnimation = 3;
		//}
	}

	public void InventoryPress (){
		if (paused == false) {
			/*if (Advertisement.IsReady())
   			{
      			Advertisement.Show();
    		}*/
			paused = true;
			NumberOfHealthPotionsText.text = NumberOfHealthPotions.ToString() + "x";
			SwordLevelText.text = "Sword Level- " + PlayerHealth.SwordLevel.ToString();
			BowLevelText.text = "Bow Level- " + PlayerHealth.BowLevel.ToString();
			MagicLevelText.text = "Magic Level- " + PlayerHealth.MagicLevel.ToString();
			if(NumberOfBagOfPoos > 0){
				NumberOfBagOfPoosText.text = NumberOfBagOfPoos.ToString() + "x";
			}
			menu.SetActive (true);
			Block.SetActive (false);
			Dash.SetActive (false);
			Primary.SetActive (false);
			Secondary.SetActive (false);
			JoyStick.SetActive (false);
			InventoryButton.SetActive (false);
		}
	}

	public void CloseInventoryPress (){
		menu.SetActive(false);
		Block.SetActive (true);
		Dash.SetActive (true);
		Primary.SetActive (true);
		Secondary.SetActive (true);
		JoyStick.SetActive (true);
		InventoryButton.SetActive (true);
		paused = false;
	}

	public void ShopPress (){
		if (paused == false) {
			Shop.SetActive (true);
			paused = true;
		}
	}

	public void CloseShopPress (){
		Shop.SetActive(false);
		paused = false;
	}

	public void BuyPotionPress (){
		if(PlayerHealth.coins >= 25){
			PlayerHealth.coins -= 25;
			NumberOfHealthPotions += 1;
		}
	}

	public void BuySecretPress (){
		if(PlayerHealth.coins >= 100){
			PlayerHealth.coins -= 100;
			NumberOfBagOfPoos += 1;
		}
	}

	public void BuyArmourPress (){
		if(PlayerHealth.coins >= 30){
			PlayerHealth.coins -= 30;
			PlayerHealth.Ohealth += 60/GameControl.control.Hardness;
			PlayerHealth.health += 60/GameControl.control.Hardness;
		}
	}

	public void UpgradeSwordPress (){
		if(PlayerHealth.coins >= 20){
			PlayerHealth.coins -= 20;
			PlayerHealth.SwordLevel += 1;
		}
	}

	public void UpgradeBowPress (){
		if(PlayerHealth.coins >= 20){
			PlayerHealth.coins -= 20;
			PlayerHealth.BowLevel += 1;
		}
	}

	public void UpgradeMagicPress (){
		if(PlayerHealth.coins >= 30){
			PlayerHealth.coins -= 30;
			PlayerHealth.MagicLevel += 1;
		}
	}

	public void PrimarySelectPress(){
		PrimarySelect = !PrimarySelect;
	}

	public void SecondarySelectPress(){
		SecondarySelect = !SecondarySelect;
	}

	public void SwordSelectPress (){
		if (PrimarySelect == true) {
			SwordEquiped = !SwordEquiped;
			if (SwordEquiped == true) {
				PrimaryActive.image.sprite = SwordImage;
				PrimaryButton.image.sprite = SwordImage;
				if(BowEquiped == true){
					SecondaryActive.image.sprite = SecondarySelectImage;
					SecondaryButton.image.sprite = SecondarySelectImage;
				}
			}
			if (SwordEquiped == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
			}
			BowEquiped = false;
			SpellEquiped = false;
			SpellEquipedF = false;
			SpellEquipedI = false;
			SpellEquipedP = false;
			PrimarySelect = false;
			Debug.Log (">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log ("S1" + SwordEquiped + "S2" + SwordEquipedS + "B1" + BowEquiped + "Sp1" + SpellEquiped + "Sp2" + SpellEquipedS + "SpF1" + SpellEquipedF + "SpF2" + SpellEquipedFS + "SpI1" + SpellEquipedI + "SpI2" + SpellEquipedIS + "SpP1" + SpellEquipedP + "SpP2" + SpellEquipedPS);
			Debug.Log ("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if (SecondarySelect == true) {
			SwordEquipedS = !SwordEquipedS;
			if (SwordEquipedS == true) {
				SecondaryActive.image.sprite = SwordImage;
				SecondaryButton.image.sprite = SwordImage;
				if(BowEquiped == true){
					PrimaryActive.image.sprite = PrimarySelectImage;
					PrimaryButton.image.sprite = PrimarySelectImage;
				}
			}
			if (SwordEquipedS == false) {
				SecondaryActive.image.sprite = SecondarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			BowEquiped = false;
			SpellEquipedS = false;
			SpellEquipedFS = false;
			SpellEquipedIS = false;
			SpellEquipedPS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void BowSelectPress(){
		if(PrimarySelect == true) {
			BowEquiped = !BowEquiped;
			if (BowEquiped == true) {
				PrimaryActive.image.sprite = BowImage;
				SecondaryActive.image.sprite = BowImage;
				PrimaryButton.image.sprite = BowImage;
				SecondaryButton.image.sprite = BowImage;
			}
			if (BowEquiped == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				SecondaryActive.image.sprite = SecondarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquiped = false;
			SpellEquiped = false;
			SwordEquipedS = false;
			SpellEquipedS = false;
			SpellEquipedF = false;
			SpellEquipedI = false;
			SpellEquipedP = false;
			SpellEquipedFS = false;
			SpellEquipedIS = false;
			SpellEquipedPS = false;
			PrimarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if(SecondarySelect == true){
			BowEquiped = !BowEquiped;
			if (BowEquiped == true) {
				PrimaryActive.image.sprite = BowImage;
				SecondaryActive.image.sprite = BowImage;
				PrimaryButton.image.sprite = BowImage;
				SecondaryButton.image.sprite = BowImage;
			}
			if (BowEquiped == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				SecondaryActive.image.sprite = SecondarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquiped = false;
			SpellEquiped = false;
			SwordEquipedS = false;
			SpellEquipedS = false;
			SpellEquipedF = false;
			SpellEquipedI = false;
			SpellEquipedP = false;
			SpellEquipedFS = false;
			SpellEquipedIS = false;
			SpellEquipedPS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void SpellSelectPress(){
		if(PrimarySelect == true) {
			SpellEquiped = !SpellEquiped;
			if (SpellEquiped == true) {
				PrimaryActive.image.sprite = SpellImage;
				PrimaryButton.image.sprite = SpellImage;
				if(BowEquiped == true){
					SecondaryActive.image.sprite = SecondarySelectImage;
					SecondaryButton.image.sprite = SecondarySelectImage;
				}
			}
			if (SpellEquiped == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
			}
			SwordEquiped = false;
			BowEquiped = false;
			SpellEquipedF = false;
			SpellEquipedI = false;
			SpellEquipedP = false;
			PrimarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if(SecondarySelect == true){
			SpellEquipedS = !SpellEquipedS;
			if (SpellEquipedS == true) {
				SecondaryActive.image.sprite = SpellImage;
				SecondaryButton.image.sprite = SpellImage;
				if(BowEquiped == true){
					PrimaryActive.image.sprite = PrimarySelectImage;
					PrimaryButton.image.sprite = PrimarySelectImage;
				}
			}
			if (SpellEquipedS == false) {
				SecondaryActive.image.sprite = SecondarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquipedS = false;
			BowEquiped = false;
			SpellEquipedFS = false;
			SpellEquipedIS = false;
			SpellEquipedPS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void SpellFSelectPress(){
		if(PrimarySelect == true) {
			SpellEquipedF = !SpellEquipedF;
			if (SpellEquipedF == true) {
				PrimaryActive.image.sprite = SpellFImage;
				PrimaryButton.image.sprite = SpellFImage;
				if(BowEquiped == true){
					SecondaryActive.image.sprite = SecondarySelectImage;
					SecondaryButton.image.sprite = SecondarySelectImage;
				}
			}
			if (SpellEquipedF == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
			}
			SwordEquiped = false;
			BowEquiped = false;
			SpellEquiped = false;
			SpellEquipedI = false;
			SpellEquipedP = false;
			PrimarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if(SecondarySelect == true){
			SpellEquipedFS = !SpellEquipedFS;
			if (SpellEquipedFS == true) {
				SecondaryActive.image.sprite = SpellFImage;
				SecondaryButton.image.sprite = SpellFImage;
				if(BowEquiped == true){
					PrimaryActive.image.sprite = PrimarySelectImage;
					PrimaryButton.image.sprite = PrimarySelectImage;
				}
			}
			if (SpellEquipedFS == false) {
				SecondaryActive.image.sprite = SecondarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquipedS = false;
			BowEquiped = false;
			SpellEquipedS = false;
			SpellEquipedIS = false;
			SpellEquipedPS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void SpellISelectPress(){
		if(PrimarySelect == true) {
			SpellEquipedI = !SpellEquipedI;
			if (SpellEquipedI == true) {
				PrimaryActive.image.sprite = SpellIImage;
				PrimaryButton.image.sprite = SpellIImage;
				if(BowEquiped == true){
					SecondaryActive.image.sprite = SecondarySelectImage;
					SecondaryButton.image.sprite = SecondarySelectImage;
				}
			}
			if (SpellEquipedI == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
			}
			SwordEquiped = false;
			BowEquiped = false;
			SpellEquiped = false;
			SpellEquipedF = false;
			SpellEquipedP = false;
			PrimarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if(SecondarySelect == true){
			SpellEquipedIS = !SpellEquipedIS;
			if (SpellEquipedIS == true) {
				SecondaryActive.image.sprite = SpellIImage;
				SecondaryButton.image.sprite = SpellIImage;
				if(BowEquiped == true){
					PrimaryActive.image.sprite = PrimarySelectImage;
					PrimaryButton.image.sprite = PrimarySelectImage;
				}
			}
			if (SpellEquipedIS == false) {
				SecondaryActive.image.sprite = SecondarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquipedS = false;
			BowEquiped = false;
			SpellEquipedS = false;
			SpellEquipedFS = false;
			SpellEquipedPS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void SpellPSelectPress(){
		if(PrimarySelect == true) {
			SpellEquipedP = !SpellEquipedP;
			if (SpellEquipedP == true) {
				PrimaryActive.image.sprite = SpellPImage;
				PrimaryButton.image.sprite = SpellPImage;
				if(BowEquiped == true){
					SecondaryActive.image.sprite = SecondarySelectImage;
					SecondaryButton.image.sprite = SecondarySelectImage;
				}
			}
			if (SpellEquipedP == false) {
				PrimaryActive.image.sprite = PrimarySelectImage;
				PrimaryButton.image.sprite = PrimarySelectImage;
			}
			SwordEquiped = false;
			BowEquiped = false;
			SpellEquiped = false;
			SpellEquipedF = false;
			SpellEquipedI = false;
			PrimarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
		if(SecondarySelect == true){
			SpellEquipedPS = !SpellEquipedPS;
			if (SpellEquipedPS == true) {
				SecondaryActive.image.sprite = SpellPImage;
				SecondaryButton.image.sprite = SpellPImage;
				if(BowEquiped == true){
					PrimaryActive.image.sprite = PrimarySelectImage;
					PrimaryButton.image.sprite = PrimarySelectImage;
				}
			}
			if (SpellEquipedPS == false) {
				SecondaryActive.image.sprite = SecondarySelectImage;
				SecondaryButton.image.sprite = SecondarySelectImage;
			}
			SwordEquipedS = false;
			BowEquiped = false;
			SpellEquipedS = false;
			SpellEquipedFS = false;
			SpellEquipedIS = false;
			SecondarySelect = false;
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
			Debug.Log("S1"+SwordEquiped+"S2"+SwordEquipedS+"B1"+BowEquiped+"Sp1"+SpellEquiped+"Sp2"+SpellEquipedS+"SpF1"+SpellEquipedF+"SpF2"+SpellEquipedFS+"SpI1"+SpellEquipedI+"SpI2"+SpellEquipedIS+"SpP1"+SpellEquipedP+"SpP2"+SpellEquipedPS);
			Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
		}
	}

	public void HealthPotion (){
		if(NumberOfHealthPotions > 0){
			NumberOfHealthPotions -= 1;
			NumberOfHealthPotionsText.text = NumberOfHealthPotions.ToString() + "x";
			PlayerHealth.health += 25;
			if(PlayerHealth.health > PlayerHealth.Ohealth){
				PlayerHealth.health = PlayerHealth.Ohealth; 
			}
		}
	}

	public void AddHealthPotion(){
		NumberOfHealthPotions += 1;
		NumberOfHealthPotionsText.text = NumberOfHealthPotions.ToString() + "x";
	}

	public void AddCoins(){
		PlayerHealth.coins += 100;
	}
}
