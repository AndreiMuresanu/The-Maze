using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using UnityEngine.SceneManagement;
//#pragma strict

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float apples;
	public float bananas;
	public int Day;
	//public GameObject Tutorial;
	//public GameObject Credits;
	//public GameObject Difficulties;
	public int Hardness;
	//bool DifficultiesBool = false;
	//public List<int> HighscoreList = new List<int>();
	//bool a = false;
	//bool b = false;
	//bool HighscoreListHasLoaded = false;
	//bool OnlyLoadingHighscoreList = false;
	//bool FirstSave = true;
	public int NewScoreA;
	public int NewScoreB;
	public int NewScoreC;
	public int NewScoreD;
	public int NewScoreE;
	public int ScoreHardnessA;
	public int ScoreHardnessB;
	public int ScoreHardnessC;
	public int ScoreHardnessD;
	public int ScoreHardnessE;

	void Awake ()
	{
		Hardness = 1;
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		//if(HighscoreList.Count == 0){
		//	HighscoreList.Add(1);
		//}
		//foreach (int score in HighscoreList) {
		//	Debug.Log ("HighscoreList: " + score.ToString ());
		//}
	}

	/*void ChangeHighscoreList (){
		Load();
		int tempInt = HighscoreList[HighscoreList.Count - 1];
		if(Day > tempInt || HighscoreList.Count < 5){
			if(HighscoreList.Count == 5){
				HighscoreList.Remove(0);
			}
			HighscoreList.Add(Day);
			HighscoreList.Sort();
		}
	}*/

	public void Save ()
	{
		Debug.Log("SAVEING STUFF");
		/*//int tempInt = HighscoreList.Last();
		if (a == false) {
		//	b = true;
		//	Load();
		}
		if(a == true){
			int tempInt = HighscoreList[HighscoreList.Count - 1];
			if(Day > tempInt || HighscoreList.Count < 5){
				if(HighscoreList.Count == 5){
					HighscoreList.Remove(0);
				}
				HighscoreList.Add(Day);
				HighscoreList.Sort();
			}
		}*/

		/*if(HighscoreListHasLoaded == false && FirstSave == false){
			OnlyLoadingHighscoreList = true;
			Load();
		}

		Debug.Log("passed the go to load thing");*/

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.apples = apples;
		data.bananas = bananas;
		//data.HighscoreList = HighscoreList;
		data.Day = Day;
		data.SwordEquiped = Pause.SwordEquiped;
		data.BowEquiped = Pause.BowEquiped;
		data.SpellEquiped = Pause.SpellEquiped;
		data.SpellEquipedF = Pause.SpellEquipedF;
		data.SpellEquipedI = Pause.SpellEquipedI;
		data.SpellEquipedP = Pause.SpellEquipedP;
		data.SwordEquipedS = Pause.SwordEquipedS;
		data.SpellEquipedS = Pause.SpellEquipedS;
		data.SpellEquipedFS = Pause.SpellEquipedFS;
		data.SpellEquipedIS = Pause.SpellEquipedIS;
		data.SpellEquipedPS = Pause.SpellEquipedPS;
		//data.health = PlayerHealth.health;
		data.Ohealth = PlayerHealth.Ohealth;
		//data.Stamina = PlayerHealth.Stamina;
		data.OStamina = PlayerHealth.OStamina;
		data.NumberOfHealthPotions = Pause.NumberOfHealthPotions;
		data.NumberOfBagsOfPoo = Pause.NumberOfBagOfPoos;
		data.coins = PlayerHealth.coins;
		data.MagicLevel = PlayerHealth.MagicLevel;
		data.SwordLevel = PlayerHealth.SwordLevel;
		data.BowLevel = PlayerHealth.BowLevel;
		data.KeyInHand = Pause.KeyInHand;
		//data.MySceneName = SceneManager.GetActiveScene().name;
		data.NewScoreA = NewScoreA;
		data.NewScoreB = NewScoreB;
		data.NewScoreC = NewScoreC;
		data.NewScoreD = NewScoreD;
		data.NewScoreE = NewScoreE;
		data.ScoreHardnessA = ScoreHardnessA;
		data.ScoreHardnessB = ScoreHardnessB;
		data.ScoreHardnessC = ScoreHardnessC;
		data.ScoreHardnessD = ScoreHardnessD;
		data.ScoreHardnessE = ScoreHardnessE;

		bf.Serialize(file, data);

		file.Close();


		//foreach (int score in HighscoreList) {
		//	Debug.Log ("HighscoreList: " + score.ToString ());
		//}
		//FirstSave = false;
		//Debug.Log(HighscoreList);
	}

	public void Load (){
		Debug.Log("LOADING STUFF");
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			/*if(b == true){
				//HighscoreList = data.HighscoreList;
				b = false;
				a = true;
				//Save();
			}
			Debug.Log("went past Save();");
			if(b == false){*/

			/*Debug.Log("came to load");

			if(OnlyLoadingHighscoreList == true){
				//if(data.HighscoreList.Count > 0){
					HighscoreList = data.HighscoreList;
				//}
				HighscoreListHasLoaded = true;
				OnlyLoadingHighscoreList = false;
				Save();
			}

			Debug.Log("passed the go to save thing");*/

				apples = data.apples;
				bananas = data.bananas;
				//HighscoreList = data.HighscoreList;
				Day = data.Day;
				Pause.SwordEquiped = data.SwordEquiped;
				Pause.BowEquiped = data.BowEquiped;
				Pause.SpellEquiped = data.SpellEquiped;
				Pause.SpellEquipedF = data.SpellEquipedF;
				Pause.SpellEquipedI = data.SpellEquipedI;
				Pause.SpellEquipedP = data.SpellEquipedP;
				Pause.SwordEquipedS = data.SwordEquipedS;
				Pause.SpellEquipedS = data.SpellEquipedS;
				Pause.SpellEquipedFS = data.SpellEquipedFS;
				Pause.SpellEquipedIS = data.SpellEquipedIS;
				Pause.SpellEquipedPS = data.SpellEquipedPS;
				//PlayerHealth.health = data.health;
				PlayerHealth.Ohealth = data.Ohealth;
				//PlayerHealth.Stamina = data.Stamina;
				PlayerHealth.OStamina = data.OStamina;
				Pause.NumberOfHealthPotions = data.NumberOfHealthPotions;
				Pause.NumberOfBagOfPoos = data.NumberOfBagsOfPoo;
				PlayerHealth.coins = data.coins;
				PlayerHealth.MagicLevel = data.MagicLevel;
				PlayerHealth.SwordLevel = data.SwordLevel;
				PlayerHealth.BowLevel = data.BowLevel;
				Pause.KeyInHand = data.KeyInHand;
				//SceneManager.LoadScene(data.MySceneName);
				NewScoreA = data.NewScoreA;
				NewScoreB = data.NewScoreB;
				NewScoreC = data.NewScoreC;
				NewScoreD = data.NewScoreD;
				NewScoreE = data.NewScoreE;
				ScoreHardnessA = data.ScoreHardnessA;
				ScoreHardnessB = data.ScoreHardnessB;
				ScoreHardnessC = data.ScoreHardnessC;
				ScoreHardnessD = data.ScoreHardnessD;
				ScoreHardnessE = data.ScoreHardnessE;
			//}
		}
		/*int tempInt = HighscoreList[HighscoreList.Count - 1];
		if(Day > tempInt || HighscoreList.Count < 5){
			if(HighscoreList.Count == 5){
				HighscoreList.Remove(0);
			}
			HighscoreList.Add(Day);
			HighscoreList.Sort();
		}
		foreach(int q in HighscoreList){
			Debug.Log(q);
		}
		Save();*/
	}
	/*
	public void NewGamePress(){
		Day = 1;
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

	public void HardPress (){
		Hardness = 4;
	}

	public void MediumPress (){
		Hardness = 2;
	}

	public void EasyPress (){
		Hardness = 1;
	}*/
}

[Serializable]
class PlayerData
{
	public float apples;
	public float bananas;
	public int Day;
	public bool SwordEquiped;
	public bool BowEquiped;
	public bool SpellEquiped;
	public bool SpellEquipedF;
	public bool SpellEquipedI;
	public bool SpellEquipedP;
	public bool SwordEquipedS;
	public bool SpellEquipedS;
	public bool SpellEquipedFS;
	public bool SpellEquipedIS;
	public bool SpellEquipedPS;
	public float health;
	public float Ohealth;
	public float Stamina;
	public float OStamina;
	public int NumberOfHealthPotions;
	public int NumberOfBagsOfPoo;
	public int coins;
	public int MagicLevel;
	public int SwordLevel;
	public int BowLevel;
	public bool KeyInHand;
	//public List<int> HighscoreList;
	//public string MySceneName;
	public int NewScoreA;
	public int NewScoreB;
	public int NewScoreC;
	public int NewScoreD;
	public int NewScoreE;
	public int ScoreHardnessA;
	public int ScoreHardnessB;
	public int ScoreHardnessC;
	public int ScoreHardnessD;
	public int ScoreHardnessE;
}

