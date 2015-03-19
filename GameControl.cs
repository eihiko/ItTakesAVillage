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

	private int resources;

	public int GetResources() {
		return resources;
	}

	public void SetResources(int resources) {
		this.resources = resources;
	}

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
		data.SetResources(this.GetResources());

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
			this.SetResources(data.GetResources());
		}
	}

	/**
	 * Quick method for incrementing the resource by an integer
	 */
	public void IncResources(int value) {
		resources += value;
	}

	/**
	 * Quick method for decrementing the resources by an integer
	 */
	public void DecResources(int value) {
		resources -= value;
	}

}

[Serializable]
class PlayerData {

	/**
	 * Place the variables you want to save in this section
	 * Also be sure to write getter/setter methods
	 */

	private int resources;

	public int GetResources() {
		return resources;
	}

	public void SetResources(int resources) {
		this.resources = resources;
	}
}
