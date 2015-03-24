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

	private int health;
	private int energy;
	private int experience;
	private string label;

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

	public void SetEnergy(int energy) {
		this.energy = energy;
	}

	public int GetEnergy() {
		return this.energy;
	}

	public void SetExperience(int experience) {
		this.experience = experience;
	}

	public int GetExperience() {
		return this.experience;
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
		data.SetHealth(this.GetHealth());
		data.SetEnergy(this.GetEnergy());
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
			this.SetHealth(data.GetHealth());
			this.SetEnergy(data.GetEnergy());
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

	private int health;
	private int energy;
	private int experience;
	private string label;

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
	
	public void SetEnergy(int energy) {
		this.energy = energy;
	}
	
	public int GetEnergy() {
		return this.energy;
	}
	
	public void SetExperience(int experience) {
		this.experience = experience;
	}
	
	public int GetExperience() {
		return this.experience;
	}

}
