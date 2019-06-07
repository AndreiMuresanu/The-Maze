/// <information>
/// Created By: Austin Takechi
/// Purpose: To use Prim's Algorithm to generate
///  a randomly structured maze of dynamic proportions.
/// Contact: MinoruTono@Gmail.com
/// </information>

/// <summary>
/// This script creates and attaches the grid,
/// and also faciliates most of Prim's Algorithm.
/// </summary>


//Included by Default
using UnityEngine; 
//using UnityEngine.Advertisements;
//Included by Default
using System.Collections;
//Allows us to use List< >
using System.Collections.Generic;
using Text=UnityEngine.UI.Text;
//using Button=UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

//This is the main Class
// All of our scripting in GridScript goes in here.
public class GridScript : MonoBehaviour {
	//The CellPrefab is a Transform Prefab
	// we use as a template to create each
	// cell. This is set in Unity's Inspector.
	public Transform CellPrefab;
	
	//Size is a Vector3, denotes the 
	// size of the Grid we're going to create.
	// Only X and Z are used, Y is set to 1 at default.
	// This is set in Unity's Inspector.
	public Vector3 Size;
	
	//Grid[ , ] is a Multidimensional Array that 
	// stores each newly created Cell in an easy
	// X,Z notation. 0-Based.
	public Transform[,] Grid;
	public float Buffer = 7;
	
	public GameObject Player;
	int spawnxpos;
	int spawnzpos;

	public GameObject Agrid;
	public GameObject Seeker;
	public GameObject SeekerA;
	public GameObject SeekerB;
	public GameObject SeekerC;
	public GameObject Minotaur;
	public GameObject Shop;
	public GameObject Wall;
	public GameObject Cam;
	public GameObject SceneViewMask;

	public static int SizeX;
	public static int SizeY;

	float s = 0;
	float m = 0;
	float h = 0;
	public Text TimeText;
	public  Light Sun;
	//public static int Day = 1;
	bool NewDay = false;
	public GameObject HpMana;
	//public Button SkipDay;
	public GameObject DayButton;
	public Text DayText;
	public GameObject TutorialG;
	public Texture WallTexture;
	public Texture ExitTexture;
	//public static bool AreYouSureExitMenu = false;
	//public bool AreYouSureExitMenuTest;
	public GameObject ExitDoorTrigger;
	public int FakeDay;
	public GameObject TouchControls;

	int p = 0;

	public void SkipDayPress(){
		GameControl.control.Day += 1;
		GameControl.control.Save();
		NewDay = true;
	}

	// Use this for initialization
	void Start () {
		//if (GameControl.control.Day <= 1) {
		//	GameControl.control.Save();
		//}
		Pause.paused = true;
		Debug.Log("Day " + GameControl.control.Day.ToString());
		HpMana.SetActive(false);
		PlayerHealth.health = PlayerHealth.Ohealth;
		PlayerHealth.Stamina = PlayerHealth.OStamina;
		PlayerHealth.dead = false;
		SwordSwing.CastingSpell = false;
		SwordSwing.FireingBow = false;
		SizeX = (int)Size.x*(int)Buffer;
		SizeY = (int)Size.z*(int)Buffer;
		SceneViewMask.transform.position = new Vector3 (SizeX/2, 10, SizeY/2);
		SceneViewMask.transform.localScale = new Vector3 (Size.x, transform.localScale.y, Size.z);
		h = 18;
		TimeText = TimeText.GetComponent<Text> ();
		Sun = Sun.GetComponent<Light> ();
		//CreateGrid will create a new grid of 
		// size X,Z; name and parent those new
		// cells, and add the cell to our Grid List< >
		CreateGrid();
		
		//SetRandomNumbers goes through each
		// of our blank cells and assigns it a
		// random weight.
		SetRandomNumbers();
		
		//Set Adjacents goes through each
		// of the cells and assigns the adjacents,
		// and then ranks the adjacents by
		// using our custom sort:
		// SortByLowestWeight( )
		SetAdjacents();
		
		//We set the entrance cell of the grid,
		// by default in the lower left corner,
		// or Grid[0,0].
		SetStart();
		
		//FindNext looks for the lowest weight adjacent
		// to all the cells in the Set, and adds that
		// cell to the Set. A cell is disqualified if
		// it has two open neighbors. This makes the 
		// maze full of deadends.
		//FindNext also will invoke itself as soon as it
		// finishes, allowing it to loop indefinitely until
		// the invoke is canceled when we detect our maze is done.
		FindNext();

		//AdSpot();
	}
	
	void CreateGrid(){
		//Resize Grid to the proper size specified in Inspector.
		// Because we use a Vector3, we need to convert the X, Y, and Z
		// from Float to Int.
		// We do that easily by adding "(int)" in front of the float.
		// This is called explicit downcasting.
		Grid = new Transform[(int)Size.x,(int)Size.z];
		
		//We now enter a Double For loop.
		// This will create each cell by looping from x = 0 while x < Size.x,
		// and then the same for z.
		for(int x = 0; x < Size.x; x++){
			for(int z = 0; z < Size.z; z++){
				//We create a new Transform to manipulate later.
				Transform newCell;
				//A new CellPrefab is Instantiated at the correct location
				// using "new Vector3(x,0,z)".
				// Quaternion.Identity is a rotation that we don't need to
				// worry about.
				newCell = (Transform)Instantiate(CellPrefab, new Vector3(x, 0, z)*Buffer, Quaternion.identity);
								newCell.localScale=newCell.localScale*Buffer;
				//The newCell is now renamed "(x,0,z)" using String.Format
				// "(+x+",0,"+z+")" would also work, but is less efficient.
				newCell.name = string.Format("({0},0,{1})",x,z);
				//For clean-ness, we parent all the newCells to the Grid gameObject.
				newCell.parent = transform;
				//We already set the position of the newCell, but the cell's attached
				// script needs to know where it is also.
				// We assign it here.
				newCell.GetComponent<CellScript>().Position = new Vector3(x, 0, z);
				//Grid[,] keeps track of all of the cells.
				// We add the newCell to the appropriate location in the Grid array.
				Grid[x,z] = newCell;
			}
		}
		//To keep the camera centered on the grid,
		// we set the position equal to the center ( X/2 , Z/2 )
		// cell in the grid. We then add Vector3.up*20f to bring
		// the camera higher than the cells.
		//Camera.main.transform.position = Grid[(int)(Size.x/2f-Buffer/2),(int)(Size.z/2f-Buffer/2)].position + Vector3.up*400f;
		Cam.SetActive (true);
		Cam.transform.position = new Vector3 (SizeX/2, 0.55785173935f*SizeX/2, SizeY/2);
		//The orthographicSize is calculated using this 
		// formula.
		//The higher the max of the X or Z size, the higher the camera
		// is positioned.
		//Camera.main.orthographicSize = Mathf.Max(Size.x*(Buffer/2), Size.z*(Buffer/2));
				spawnxpos = (int)(Size.x / 2f);
				spawnzpos = (int)(Size.z / 2f);
	}
	
	void SetRandomNumbers(){
		//ForEach cell in the Grid gameObject:
		foreach(Transform child in transform){
			//Get a new random number between 0 and 10.
			int weight = Random.Range(0,10);
			//Assign that number to both the cell's text..
			child.GetComponentInChildren<TextMesh>().text = weight.ToString();
			//..and Weight variable in the CellScript.
			child.GetComponent<CellScript>().Weight = weight;
		}
	}
	
	void SetAdjacents(){
		//Double For loop acts as a ForEach
		for(int x = 0; x < Size.x; x++){
			for(int z = 0; z < Size.z; z++){
				//Create a new variable to be the
				// cell at position x, z.
				Transform cell;
				cell = Grid[x,z];
				//Create a new CellScript variable to
				// hold the cell's script component.
				CellScript cScript = cell.GetComponent<CellScript>();
				//As long as it is valid,
				// Add the left, right, down and up cells adjacent
				// to the list inside this cell's cellScript.
				if(x - 1 >= 0){
					cScript.Adjacents.Add(Grid[x-1,z]);
				}
				if(x + 1 < Size.x){
					cScript.Adjacents.Add(Grid[x+1,z]);
				}
				if(z - 1 >= 0){
					cScript.Adjacents.Add(Grid[x,z-1]);
				}
				if(z + 1 < Size.z){
					cScript.Adjacents.Add(Grid[x,z+1]);
				}
				//After each cell has been validated and entered,
				// sort all the adjacents in the list
				// by the lowest weight.
				cScript.Adjacents.Sort(SortByLowestWeight);
			}
		}
	}
	
	//Check the link for more info on custom comparers and sorts.
	//http://msdn.microsoft.com/en-us/library/0e743hdt.aspx
	int SortByLowestWeight(Transform inputA, Transform inputB){
		//Given two transforms, find which cellScript's Weight
		// is the highest. Sort by the Weights.
		int a = inputA.GetComponent<CellScript>().Weight; //a's weight
		int b = inputB.GetComponent<CellScript>().Weight; //b's weight
		return a.CompareTo(b);
	}
	
	//This list is used for Prim's Algorithm.
	// We start with an empty list,
	// but as the maze is created, cells will be
	// continuously added to this Set list.
	// Look at the Wikipedia page for more info
	// on Prim's.
	// http://en.wikipedia.org/wiki/Prim%27s_algorithm
	public List<Transform> Set;
	
	//Here we have a List of Lists.
	// Here is the structure:
	//  AdjSet{
	//       [ 0 ] is a list of all the cells
	//         that have a weight of 0, and are
	//         adjacent to the cells in Set.
	//       [ 1 ] is a list of all the cells
	//         that have a weight of 1, and are
	//         adjacent to the cells in Set.
	//       [ 2 ] is a list of all the cells
	//         that have a weight of 2, and are
	//         adjacent to the cells in Set.
	//     etc...
	//       [ 9 ] is a list of all the cells
	//         that have a weight of 9, and are
	//         adjacent to the cells in Set.
	//  }
	//
	// Note: Multiple entries of the same cell
	//  will not appear as duplicates.
	//  (Some adjacent cells will be next to
	//  two or three or four other Set cells).
	//  They are only recorded in the AdjSet once.
	public List<List<Transform>> AdjSet;
	
	void SetStart(){
		//Create a new List<Transform> for Set.
		Set = new List<Transform>();
		//Also, we create a new List<List<Transform>>
		// and in the For loop, List<Transform>'s.
		AdjSet = new List<List<Transform>>();
		for(int i = 0; i < 10; i++){
			AdjSet.Add(new List<Transform>());	
		}
		//The Start of our Maze/Set will be color
		// coded Green, so we apply that to the renderer's
		// material's color here.
		//Grid[0,0].GetComponent<Renderer>().material.color = Color.green;
		// Andrei- So maze start in midle use for maze starts at player pos
		Grid[spawnxpos,spawnzpos].GetComponent<Renderer>().material.color = Color.green;
		//Now, we add the first cell to the Set.
		//AddToSet(Grid[0,0]);
		//Andrei- Same needed here from above /\
		AddToSet(Grid[spawnxpos,spawnzpos]);
	}
	
	void AddToSet(Transform toAdd){
		//Adds the toAdd object to the Set.
		// The toAdd transform is sent as a parameter.
		Set.Add(toAdd);
		//For every adjacent next to the toAdd object:
		foreach(Transform adj in toAdd.GetComponent<CellScript>().Adjacents){
			//Add one to the adjacent's cellScript's AdjacentsOpened
			adj.GetComponent<CellScript>().AdjacentsOpened++;
			//If
			// a) The Set does not contain the adjacent
			//   (cells in the Set are not valid to be entered as
			//   adjacentCells as well).
			//  and
			// b) The AdjSet does not already contain the adjacent cell.
			// then..
			if(!Set.Contains(adj) && !(AdjSet[adj.GetComponent<CellScript>().Weight].Contains(adj))){
				//.. Add this new cell into the proper AdjSet sub-list.
				AdjSet[adj.GetComponent<CellScript>().Weight].Add(adj);
			}
		}
	}
	
	void FindNext(){
		//We create an empty Transform variable
		// to store the next cell in.
		Transform next;
		//Perform this loop 
		// While:
		//  The proposed next gameObject's AdjacentsOpened
		//   is less than or equal to 2.
		//   This is to ensure the maze-like structure.
		do{
			//We'll initially assume that each sub-list of AdjSet is empty
			// and try to prove that assumption false in the for loop.
			// This boolean value will keep track.
			bool empty = true;
			//We'll also take a note of which list is the Lowest,
			// and store it in this variable.
			int lowestList = 0;
			for(int i = 0; i < 10; i++){
				//We loop through each sub-list in the AdjSet list of
				// lists, until we find one with a count of more than 0.
				// If there are more than 0 items in the sub-list,
				// it is not empty.
				//We then stop the loop by using the break keyword;
				// We've found the lowest sub-list, so there is no need
				// to continue searching.
				lowestList = i;
				if(AdjSet[i].Count > 0){
					empty = false;
					break;
				}
			}
			//There is a chance that none of the sub-lists of AdjSet will
			// have any items in them.
			//If this happens, then we have no more cells to open, and
			// are done with the maze production.
			if(empty){ 
				//If we finish, as stated and determined above,
				// display a message to the DebugConsole
				// that includes how many seconds it took to finish.
				//Debug.Log("We're Done, "+Time.timeSinceLevelLoad+" seconds taken"); 
				//Then, cancel our recursive invokes of the FindNext function,
				// as we're done with the maze.
				//If we allowed the invokes to keep going, we will receive an error.
				CancelInvoke("FindNext");
				//Set.Count-1 is the index of the last element in Set,
				// or the last cell we opened.
				//This will be marked as the end of our maze, and so
				// we mark it red.
				//Set[Set.Count-1].GetComponent<Renderer>().material.color = Color.yellow;
				//Here's an extra something I put in myself.
				//Every cell in the grid that is not in the set
				// will be moved one unit up and turned black.
				// (I changed the default color from black to clear earlier).
				// If you instantiate a FirstPersonController in the maze now,
				// you can actually try walking through it.
				// It's really hard.
				//Andrei-sets number x square to colour use 4 shops 
				//Set[(Set.Count *4)/5].GetComponent<Renderer>().material.color = Color.green;
				Set[15].GetComponent<Renderer>().material.color = Color.blue;
				Set[Set.Count /2].GetComponent<Renderer>().material.color = Color.blue;
				//Andrei-makes player at wanted pos
				//Instantiate(Player, new Vector3(spawnxpos*Buffer,5,spawnzpos*Buffer), Quaternion.identity);
				foreach(Transform cell in Grid){
					if(!Set.Contains(cell)){
						cell.Translate(Vector3.up*Buffer/2);
						cell.GetComponent<Renderer>().material.mainTexture = WallTexture;
						//float scaleX = Mathf.Cos(Time.time) * 0.5F + 1;
        				//float scaleY = Mathf.Sin(Time.time) * 0.5F + 1;
						cell.GetComponent<Renderer>().material.mainTextureScale = new Vector2(2, 2);
						//cell.GetComponent<Renderer>().material.color = Color.cyan;
						cell.name = "Destructible";
					}
				}
				Cam.SetActive (false);
				gameObject.transform.position = new Vector3(-(Size.x/2*Buffer)+Buffer/2,0,-(Size.z/2*Buffer)+Buffer/2);
				SceneViewMask.transform.position = new Vector3 (0,0,0);
				if(Size.x % 2 == 0){
					Player.transform.position = new Vector3(Buffer/2,Buffer/2+1,Buffer/2);
				}
				if(Size.x % 2 != 0){
					Player.transform.position = new Vector3(Set[0].position.x, Buffer/2+1,Set[0].position.y);
				}
				HpMana.SetActive(true);
				//ONLY for pc
				TouchControls.SetActive(false);
				//ONLY for android
				/*if (Advertisement.IsReady() && GameControl.control.Day > 1){
	      			Advertisement.Show();
	      			//Debug.Log("ADShouldHaveShown");
	    		}*/
				if (GameControl.control.Day <= 1) {
					GameControl.control.Save();
				}
	    		//Debug.Log("PassedTheAd");
				//4 negative size
				//Player.transform.position = new Vector3(Set[0].position.x, Buffer/2+1,Set[0].position.y);
				//4 positive size
				//Player.transform.position = new Vector3(Buffer/2,Buffer/2+1,Buffer/2);
				StartCoroutine ("Time");
				Instantiate(Shop, new Vector3(Set[15].position.x, Buffer/2+1.1f, Set[15].position.z), Quaternion.identity);
				Instantiate(Shop, new Vector3(Set[Set.Count /2].position.x, Buffer/2+1.1f, Set[Set.Count /2].position.z), Quaternion.identity);
				Instantiate(Agrid, new Vector3(0, 6, 0), Quaternion.identity);
				//Instantiate(Wall, new Vector3 (transform.position.x + (Size.x*Buffer+Buffer), 0, transform.position.z + (Size.z*Buffer+Buffer)), Quaternion.identity);
				Instantiate(Wall, new Vector3 (transform.position.x + (Size.x*Buffer+Buffer/Buffer-1), Buffer/2, 0), Quaternion.identity);
				Instantiate(Wall, new Vector3 (0, Buffer/2, transform.position.z + (Size.z*Buffer+Buffer/Buffer-1)), Quaternion.identity);
				Instantiate(Wall, new Vector3 (-(transform.position.x + (Size.x*Buffer+Buffer/Buffer-1)), Buffer/2, 0), Quaternion.identity);
				Instantiate(Wall, new Vector3 (0, Buffer/2, -(transform.position.z + (Size.z*Buffer+Buffer/Buffer-1))), Quaternion.identity);
				Wall = GameObject.Find("Wall(Clone)");
				Wall.transform.localScale = new Vector3(Buffer, Buffer, Size.z*Buffer+Buffer); 
				//Wall.GetComponent<Renderer>().material.color = Color.cyan;
				Wall.name = "Andrei";
				Wall = GameObject.Find("Wall(Clone)");
				Wall.transform.localScale = new Vector3(Size.x*Buffer+Buffer, Buffer, Buffer); 
				//Wall.GetComponent<Renderer>().material.color = Color.cyan;
				Wall.name = "Andrei";
				Wall = GameObject.Find("Wall(Clone)");
				Wall.transform.localScale = new Vector3(Buffer, Buffer, Size.z*Buffer+Buffer); 
				//Wall.GetComponent<Renderer>().material.color = Color.cyan;
				Wall.name = "Andrei";
				Wall = GameObject.Find("Wall(Clone)");
				Wall.transform.localScale = new Vector3(Size.x*Buffer+Buffer, Buffer, Buffer); 
				//Wall.GetComponent<Renderer>().material.color = Color.cyan;
				Wall.name = "Andrei";
				//Agrid.transform.localScale = new Vector3(Size.x*Buffer, 1, Size.y*Buffer);
				//Agrid = GameObject.Find ("Agrid(Clone)").GetComponent<Grid> ();
				foreach(Transform item in Set){
					int index = Set.IndexOf(item);
					if(index % 4 == 0 && index != 0){
						//print(item);
						//item.GetComponent<Renderer>().material.color = Color.red;
						if(p == 0){
							Instantiate(Seeker, new Vector3(item.position.x, Buffer/2+1, item.position.z), Quaternion.identity);
							p++;
						}
						else if(p == 1){
							Instantiate(SeekerA, new Vector3(item.position.x, Buffer/2+1, item.position.z), Quaternion.identity);
							p++;
						}
						else if(p == 2){
							Instantiate(SeekerB, new Vector3(item.position.x, Buffer/2+1, item.position.z), Quaternion.identity);
							p++;
						}
						else{
							Instantiate(SeekerC, new Vector3(item.position.x, Buffer/2+1, item.position.z), Quaternion.identity);
							p = 0;
						}
					}
				}
				//Set[(Set.Count *4)/5].GetComponent<Renderer>().material.color = Color.green;
				//Set[Set.Count-1].GetComponent<Renderer>().material.color = Color.yellow;
				Set[(Set.Count *4)/5].GetComponent<Renderer>().material.mainTexture = ExitTexture;
				Instantiate(ExitDoorTrigger, new Vector3(Set[(Set.Count *4)/5].position.x, Buffer/2+1, Set[(Set.Count *4)/5].position.z), Quaternion.identity);
				Instantiate(Minotaur, new Vector3(Set[Set.Count-1].position.x, Buffer/2+1, Set[Set.Count-1].position.z), Quaternion.identity);
				//Instantiate(Seeker, new Vector3(Set[Set.Count -1].position.x, Buffer/2+1, Set[Set.Count -1].position.z), Quaternion.identity);
				return;
			}
			//If we did not finish, then:
			// 1. Use the smallest sub-list in AdjSet
			//     as found earlier with the lowestList
			//     variable.
			// 2. With that smallest sub-list, take the first
			//     element in that list, and use it as the 'next'.
			next = AdjSet[lowestList][0];
			//Since we do not want the same cell in both AdjSet and Set,
			// remove this 'next' variable from AdjSet.
			AdjSet[lowestList].Remove(next);
		}while(next.GetComponent<CellScript>().AdjacentsOpened >= 2);
		//The 'next' transform's material color becomes white.
		next.GetComponent<Renderer>().material.color = Color.grey;
		//We add this 'next' transform to the Set our function.
		AddToSet(next);
		//Recursively call this function as soon as this function
		// finishes.
		Invoke("FindNext", 0);
		DayText.text = "Day " + GameControl.control.Day.ToString() + "\nTap to start"; 
		DayButton.SetActive(true);
		//Pause.paused = true;
		if(GameControl.control.Day == 1){
			TutorialG.SetActive(true);
		}
	}

	/*void AdSpot(){
		if (Advertisement.IsReady()){
      		Advertisement.Show();
      		Debug.Log("ADShouldHaveShown");
    	}
    	Debug.Log("PassedTheAd");
	}*/

	public void DayButtonPress (){
		DayButton.SetActive(false);
		Pause.paused = false;
	}

	public void YahGotItButtonPress (){
		TutorialG.SetActive(false);
	}

	void Update ()
	{
		FakeDay = GameControl.control.Day;
		//AreYouSureExitMenu = AreYouSureExitMenuTest;
		//When we press the F1 key,
		// we're gonna restart the level.
		// This is for testing purposes.
		if (NewDay == true) {
			SceneManager.LoadScene ("LoS test scene");	
		}
		if (h >= 10 && m >= 10 && s < 10) {
			TimeText.text = h.ToString () + ":" + m.ToString () + ":0" + s.ToString ();
		}
		if (h >= 10 && m < 10 && s < 10) {
			TimeText.text = h.ToString () + ":0" + m.ToString () + ":0" + s.ToString ();
		}
		if (h < 10 && m < 10 && s < 10) {
			TimeText.text = "0" + h.ToString () + ":0" + m.ToString () + ":0" + s.ToString ();
		}
		if (h < 10 && m >= 10 && s < 10) {
			TimeText.text = "0" + h.ToString () + ":" + m.ToString () + ":0" + s.ToString ();
		}
		if (h < 10 && m >= 10 && s >= 10) {
			TimeText.text = "0" + h.ToString () + ":" + m.ToString () + ":" + s.ToString ();
		}
		if (h >= 10 && m < 10 && s >= 10) {
			TimeText.text = h.ToString () + ":0" + m.ToString () + ":" + s.ToString ();
		}
		if (h < 10 && m < 10 && s >= 10) {
			TimeText.text = "0" + h.ToString () + ":0" + m.ToString () + ":" + s.ToString ();
		}	
		if (h >= 10 && m >= 10 && s >= 10) {
			TimeText.text = h.ToString () + ":" + m.ToString () + ":" + s.ToString ();
		}
		if (h + m / 100 <= 12) {
			Sun.intensity = (h + m / 100) / 10;
		}
		if (h + m / 100 > 12) {
			Sun.intensity = (12 - ((h + m / 100) - 12)) /10;
		}
	}

	IEnumerator Time(){
		while(h <= 24 && PlayerHealth.dead == false){
			if(h== 6 && m == 0){
				GameControl.control.Day += 1;
				GameControl.control.Save();
				NewDay = true;
			}
			yield return new WaitForSeconds (0.1f);
			s += 15;
			if(s == 60){
				s = 0;
				m += 1;
				if(m == 60){
					m = 0;
					h += 1;
					if(h == 24){
						h = 0;
					}
				}
			}
		}
	}
}
