using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

/**
 * This script allows you to store any variables you want
 * and have those variables persist over scenes.
 * You could make several of these scripts to
 * hold specific data (Player, Enemy, etc.).
 */
public class GameControl : MonoBehaviour {

	public static GameControl control;

	/**
	 * Put variables that you would want to persist 
	 * through scenes here: experience, health,
	 * money, items, armor, etc.
	 * Make sure to provide getter setter methods
	 * for every variable.
	 */

	// Resources //
	private int stone;
	private int coin;
	private int food;
	private int silk;
	private int lumber;
	private int energy;
	private int morale;
	private int XPos;
	private int YPos;

	// Overworld - Building Placement //
	private bool[,] grid;
	private List<Building> buildings;

	// Life Tasks //
	private string input;
	private string tips;

	private int health;
	private int experience;
	private string label;

	public void addToJournal(String s){
		input = input + s + "\n"; 
	}
	public String getJournal(){
		return input;
	}
	public void SetStone(int stone) {
		this.stone = stone;
	}
	public int GetStone() {
		return this.stone;
	}
	
	public void SetCoin(int coin) {
		this.coin = coin;
	}
	public int GetCoin() {
		return this.coin;
	}

	public void SetFood(int food) {
		this.food = food;
	}
	public int GetFood() {
		return this.food;
	}
	
	public void SetSilk(int silk) {
		this.silk = silk;
	}
	public int GetSilk() {
		return this.silk;
	}
	
	public void SetLumber(int lumber) {
		this.lumber = lumber;
	}
	public int GetLumber() {
		return this.lumber;
	}
	
	public void SetEnergy(int energy) {
		this.energy = energy;
	}
	public int GetEnergy() {
		return this.energy;
	}
	
	public void SetMorale(int morale) {
		this.morale = morale;
	}
	public int GetMorale() {
		return this.morale;
	}

	public void SetGrid(bool[,] grid) {
		this.grid = grid;
	}
	public bool[,] GetGrid() {
		return grid;
	}

	public void SetBuildings(List<Building> buildings) {
		this.buildings = buildings;
	}
	public List<Building> GetBuildings() {
		return buildings;
	}

	public void SetInput(string input) {
		this.input = input;
	}
	public string GetInput() {
		return input;
	}

	public void SetTips(string tips) {
		this.tips = tips;
	}
	public string GetTips() {
		return tips;
	}

	public void SetLabel(string label) {
		this.label = label;
	}
	public string GetLabel() {
		return label;
	}

	public void SetHealth(int health) {
		this.health = health;
	}
	public int GetHealth() {
		return this.health;
	}

	public void SetExperience(int experience) {
		this.experience = experience;
	}
	public int GetExperience() {
		return this.experience;
	}
	
	public bool UseStone(int stone) {
		if(this.stone >= stone){
			this.stone -= stone;
			return true;
		}
		return false;
	}
	public bool UseCoin(int coin) {
		if(this.coin >= coin){
			this.coin -= coin;
			return true;
		}
		return false;
	}
	public bool UseFood(int food) {
		if(this.food >= food){
			this.food -= food;
			return true;
		}
		return false;
	}
	public bool UseSilk(int silk) {
		if(this.silk >= silk){
			this.silk -= silk;
			return true;
		}
		return false;
	}
	public bool UseLumber(int lumber) {
		if(this.lumber >= lumber){
			this.lumber -= lumber;
			return true;
		}
		return false;
	}
	public bool UseEnergy(int energy) {
		if(this.energy >= energy){
			this.energy -= energy;
			return true;
		}
		return false;
	}
	public bool UseMorale(int morale) {
		if(this.morale >= morale){
			this.morale -= morale;
			return true;
		}
		return false;
	}
	
	public bool AddStone(int stone){
		this.stone += stone;
		return true;
	}
	public bool AddCoin(int coin){
		this.coin += coin;
		return true;
	}
	public bool AddFood(int food){
		this.food += food;
		return true;
	}
	public bool AddSilk(int silk){
		this.silk += silk;
		return true;
	}
	public bool AddLumber(int lumber){
		this.lumber += lumber;
		return true;
	}
	public bool AddEnergy(int energy){
		this.energy += energy;
		return true;
	}
	public bool AddMorale(int morale){
		this.morale += morale;
		return true;
	}

	//////// DEMO METHODS /////////
	public void IncHealth() {
		health++;
	}

	public void DecHealth() {
		health--;
	}

	public void IncEnergy() {
		energy++;
	}

	public void DecEnergy() {
		energy--;
	}

	public void IncExperience() {
		experience++;
	}

	public void DecExperience() {
		experience--;
	}

	//////// DEMO METHODS ////////

	/**
	 * Produces a singleton on awake
	 */
	private void Awake() {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		} 
	}

	/**
	 * Saves all relevant data to a file based on the
	 * integer input
	 * NOTE: This does not perform a write back but
	 * rather creates a fresh file every time.
	 */
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

		PlayerData data = new PlayerData();
		// Insert data from controller to data object
		// ie: data.setExp(this.getExp());
		data.SetStone(this.GetStone());
		data.SetCoin(this.GetCoin());
		data.SetFood(this.GetFood());
		data.SetSilk(this.GetSilk());
		data.SetLumber(this.GetLumber());
		data.SetEnergy(this.GetEnergy());
		data.SetMorale(this.GetMorale());
		
		data.SetGrid (this.ConvertMatrix (this.GetGrid ()));
		data.SetBuildings (this.GetBuildings ());

		data.SetInput (this.GetInput ());
		data.SetTips (this.GetTips ());

		data.SetHealth(this.GetHealth());
		data.SetExperience(this.GetExperience());
		data.SetLabel(this.GetLabel());

		bf.Serialize(file, data);
		file.Close();
	}

	/**
	 * Loads all relevant data from a file based
	 * on some integer input
	 */
	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/playerinfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			// Reassign all variables here
			// ie: this.setHealth(data.getHealth());
			this.SetStone(data.GetStone());
			this.SetCoin(data.GetCoin());
			this.SetFood(data.GetFood());
			this.SetSilk(data.GetSilk());
			this.SetLumber(data.GetLumber());
			this.SetEnergy(data.GetEnergy());
			this.SetMorale(data.GetMorale());

			if (grid != null) {
				this.SetGrid (data.ConvertArray(data.GetGrid(), grid.GetLength(0), grid.GetLength(1)));
			}
			this.SetBuildings(data.GetBuildings());

			this.SetInput(data.GetInput());
			this.SetTips (data.GetTips());
			
			this.SetHealth(data.GetHealth());
			this.SetExperience(data.GetExperience());
			this.SetLabel(data.GetLabel());
		}
	}

	/**
	 * Quick method for calling the next level
	 */
	public void LoadNextScreen(string level) {
		Application.LoadLevel(level);
	}

	// Converts matrix to array
	public SerializableMatrix ConvertMatrix(bool[,] matrix) {
		if (matrix == null) {
			return null;
		}
		SerializableMatrix sMatrix = new SerializableMatrix(matrix.Length);
		int x = 0;
		for (int i = 0; i < matrix.GetLength(0); i++) {
			for (int j = 0; j < matrix.GetLength(1); j++) {
				sMatrix.bools[x] = matrix[i,j];
				x++;
			}
		}
		return sMatrix;
	}

	
}

[Serializable]
class PlayerData {

	/**
	 * Place the variables you want to save in this section
	 * Also be sure to write getter/setter methods
	 */

	private int stone;
	private int coin;
	private int food;
	private int silk;
	private int lumber;
	private int energy;
	private int morale;

	private SerializableMatrix grid;
	private List<Building> buildings;

	private string input;
	private string tips;

	private int health;
	private int experience;
	private string label;

	public void addToJournal(String s){
		input = input + s + "\n"; 
	}
	public String getJournal(){
		return input;
	}
	public void SetStone(int stone) {
		this.stone = stone;
	}
	public int GetStone() {
		return this.stone;
	}
	
	public void SetCoin(int coin) {
		this.coin = coin;
	}
	public int GetCoin() {
		return this.coin;
	}
	
	public void SetFood(int food) {
		this.food = food;
	}
	public int GetFood() {
		return this.food;
	}
	
	public void SetSilk(int silk) {
		this.silk = silk;
	}
	public int GetSilk() {
		return this.silk;
	}
	
	public void SetLumber(int lumber) {
		this.lumber = lumber;
	}
	public int GetLumber() {
		return this.lumber;
	}
	
	public void SetEnergy(int energy) {
		this.energy = energy;
	}
	public int GetEnergy() {
		return this.energy;
	}
	
	public void SetMorale(int morale) {
		this.morale = morale;
	}
	public int GetMorale() {
		return this.morale;
	}

	public void SetGrid(SerializableMatrix array) {
		this.grid = array;
	}
	public SerializableMatrix GetGrid() {
		return grid;
	}

	public void SetBuildings(List<Building> buildings) {
		this.buildings = buildings;
	}
	public List<Building> GetBuildings() {
		return buildings;
	}

	public void SetInput(string input) {
		this.input = input;
	}
	public string GetInput() {
		return input;
	}

	public void SetTips(string tips) {
		this.tips = tips;
	}
	public string GetTips() {
		return tips;
	}

	public string GetLabel() {
		return label;
	}
	public void SetLabel(string label) {
		this.label = label;
	}
	
	public void SetHealth(int health) {
		this.health = health;
	}
	public int GetHealth() {
		return this.health;
	}
	
	public void SetExperience(int experience) {
		this.experience = experience;
	}
	public int GetExperience() {
		return this.experience;
	}

	public void setCoordinates(int XPos, int YPos) {

	}

	// Converts array to matrix
	public bool[,] ConvertArray(SerializableMatrix array, int width, int height) {
		if (array == null) {
			return null;
		}
		bool[,] bools = new bool[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				bools[i, j] = array.bools[i + j*width];
			}
		}
		return bools;
	}
}

[Serializable]
public class SerializableMatrix {
	public bool[] bools;
			
	public SerializableMatrix(int size) {
		bools = new bool[size];
	}
}
