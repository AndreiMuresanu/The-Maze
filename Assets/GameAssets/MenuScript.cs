using UnityEngine;
using Text=UnityEngine.UI.Text;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public GameObject Tutorial;
	public GameObject Credits;
	public GameObject Difficulties;
	//public int Hardness;
	bool DifficultiesBool = false;
	public GameObject HighscoreBourd;
	public Text HighscoreText;


	//public Button NewGame;

	//void Start () {
	//	NewGame = NewGame.GetComponent<Button> ();
	//}

	void Start(){
		GameControl.control.Load();
	}

	public void NewGamePress (){
		/*if (GameControl.control.HighscoreList.Count == 0) {
			GameControl.control.HighscoreList.Add(1);
		}
		int tempInt = GameControl.control.HighscoreList[GameControl.control.HighscoreList.Count - 1];
		//if(GameControl.control.Day > tempInt || GameControl.control.HighscoreList.Count < 5){
			if(GameControl.control.HighscoreList.Count == 5){
			//	GameControl.control.HighscoreList.Remove(0);
			}
			GameControl.control.HighscoreList.Add(GameControl.control.Day);
			GameControl.control.HighscoreList.Sort();
		//}
		foreach (int score in GameControl.control.HighscoreList) {
			Debug.Log ("HighscoreList: " + score.ToString ());
		}*/
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
		GameControl.control.Day = 1;
		PlayerHealth.coins = 0;
		PlayerHealth.MagicLevel = 0;
		PlayerHealth.SwordLevel = 0;
		PlayerHealth.BowLevel = 0;
		Pause.NumberOfBagOfPoos = 0;
		Pause.NumberOfHealthPotions = 0;
		Pause.KeyInHand = false;
		PlayerHealth.Ohealth = 100;
		PlayerHealth.OStamina = 50;
		SceneManager.LoadScene ("LoS test scene");
	}

	public void LoadGamePress(){
		if(GameControl.control.Day < 1){
			GameControl.control.Day = 1;
			PlayerHealth.coins = 0;
			PlayerHealth.MagicLevel = 0;
			PlayerHealth.SwordLevel = 0;
			PlayerHealth.BowLevel = 0;
			Pause.NumberOfBagOfPoos = 0;
			Pause.NumberOfHealthPotions = 0;
			Pause.KeyInHand = false;
			PlayerHealth.Ohealth = 100;
			PlayerHealth.OStamina = 50;
		}
		SceneManager.LoadScene ("LoS test scene");
	}

	public void TutorialButtonPress (){
		Tutorial.SetActive(true);
	}

	public void YahGotItButtonPress (){
		Tutorial.SetActive(false);
	}

	public void CreditButtonPress (){
		Credits.SetActive(true);
	}

	public void SecondeYahGotItButtonPress (){
		Credits.SetActive(false);
	}

	public void OpenDifficultiesPress(){
		DifficultiesBool = !DifficultiesBool;
		Difficulties.SetActive(DifficultiesBool);
	}

	public void HighscoresPress (){
		HighscoreBourd.SetActive(true);
		HighscoreText.text = "Highscores\n\n|1|      " + GameControl.control.NewScoreA.ToString() + " Days,  Difficulty: " + GameControl.control.ScoreHardnessA.ToString() +
			"\n\n|2|      " + GameControl.control.NewScoreB.ToString() + " Days,  Difficulty: " + GameControl.control.ScoreHardnessB.ToString() +
			"\n\n|3|      " + GameControl.control.NewScoreC.ToString() + " Days,  Difficulty: " + GameControl.control.ScoreHardnessC.ToString() +
			"\n\n|4|      " + GameControl.control.NewScoreD.ToString() + " Days,  Difficulty: " + GameControl.control.ScoreHardnessD.ToString() +
			"\n\n|5|      " + GameControl.control.NewScoreE.ToString() + " Days,  Difficulty: " + GameControl.control.ScoreHardnessE.ToString();
	}

	public void OkCoolButtonPress (){
		HighscoreBourd.SetActive(false);
	}

	public void HardPress (){
		GameControl.control.Hardness = 3;
	}

	public void MediumPress (){
		GameControl.control.Hardness = 2;
	}

	public void EasyPress (){
		GameControl.control.Hardness = 1;
	}
}
