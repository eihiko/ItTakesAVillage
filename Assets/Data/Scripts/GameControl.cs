using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
	 
	private int stone;
	private int coin;
	private int food;
	private int silk;
	private int lumber;
	private int energy;
	private int morale;
	private int XPos;
	private int YPos;

	private int health;
	private int experience;
	private string label;

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
		// Insert data from contoller to data object
		// ie: data.setExp(this.getExp());
		data.SetStone(this.GetStone());
		data.SetCoin(this.GetCoin());
		data.SetFood(this.GetFood());
		data.SetSilk(this.GetSilk());
		data.SetLumber(this.GetLumber());
		data.SetEnergy(this.GetEnergy());
		data.SetMorale(this.GetMorale());
		
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
	
	private int health;
	private int experience;
	private string label;
	
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

}
