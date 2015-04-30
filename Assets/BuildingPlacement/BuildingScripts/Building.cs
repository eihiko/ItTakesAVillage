using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

	public Vector2 size; //how many squares it takes up
	public int stoneCost;
	public int coinCost;
	public int foodCost;
	public int silkCost;
	public int lumberCost;
	public int energyCost;
	public int moraleCost;
	public int stoneCollectRate;
	public int coinCollectRate;
	public int foodCollectRate;
	public int silkCollectRate;
	public int lumberCollectRate;
	public int energyCollectRate;
	public int moraleCollectRate;
	public int[] placeUnlockTypes;
	public int rotation;

	public int buildingType;
	private int x;
	private int y;

	private float stoneCollected;
	private float coinCollected;
	private float foodCollected;
	private float silkCollected;
	private float lumberCollected;
	private float energyCollected;
	private float moraleCollected;

	public int lastCollection=0;
	
	public bool locked; //we may want to replace this with something better

	// Use this for initialization
	void Start () {
		if (lastCollection == 0)
			lastCollection = getTimestamp();
	}

	public bool HaveResources() {
		GameControl c = GameControl.control;
		return (stoneCost <= c.GetStone () && coinCost <= c.GetCoin () && foodCost <= c.GetFood ()
						&& silkCost <= c.GetSilk () && lumberCost <= c.GetLumber () &&
						energyCost <= c.GetEnergy() && moraleCost <= c.GetMorale ());
	}

	public bool SpendResources() {
		GameControl c = GameControl.control;
		
		if (!HaveResources ()) { 
			return false; 
		}
		
		c.UseStone (stoneCost);
		c.UseCoin (coinCost);
		c.UseFood (foodCost);
		c.UseSilk (silkCost);
		c.UseLumber (lumberCost);
		c.UseEnergy (energyCost);
		c.UseMorale (moraleCost);
		
		return true;
	}

	//This can be called for a visual effect when there is a conflict
	public void setConflict(bool isConflict) {
		//Temporary code
		/*if (isConflict) {
				this.renderer.material;
		} else {
			this.renderer.material.color.b = 255;
		}*/
	}

	public int rotate() {
		float temp = size.x;
		size.x = size.y;
		size.y = temp;
		rotation++;
		this.gameObject.transform.RotateAround (transform.position, transform.up, 90f);
		rotation %= 4;
		return rotation;
	}

	public string CollectResources() {
		//Debug.Log ("Collecting resources");
		GameControl c = GameControl.control;
		string collection = "";

		int seconds_passed = getTimestamp () - lastCollection;
		stoneCollected += seconds_passed/60f * stoneCollectRate;
		coinCollected += seconds_passed/60f * coinCollectRate;
		foodCollected += seconds_passed/60f * foodCollectRate;
		silkCollected += seconds_passed/60f * silkCollectRate;
		lumberCollected += seconds_passed/60f * lumberCollectRate;
		energyCollected += seconds_passed/60f * energyCollectRate;
		moraleCollected += seconds_passed/60f * moraleCollectRate;

		if ((int)stoneCollected > 0)
						collection += (int)stoneCollected + " stone\n";
		c.AddStone ((int)stoneCollected);
		stoneCollected -= (int)stoneCollected;

		if ((int)coinCollected > 0)
			collection += (int)coinCollected + " coin\n";
		c.AddCoin ((int)coinCollected);
		coinCollected -= (int)coinCollected;

		if ((int)foodCollected > 0)
			collection += (int)foodCollected + " food\n";
		c.AddFood ((int)foodCollected);
		foodCollected -= (int)foodCollected;

		if ((int)silkCollected > 0)
			collection += (int)silkCollected + " silk\n";
		c.AddSilk ((int)silkCollected);
		silkCollected -= (int)silkCollected;

		if ((int)lumberCollected > 0)
			collection += (int)lumberCollected + " lumber\n";
		c.AddLumber ((int)lumberCollected);
		lumberCollected -= (int)lumberCollected;

		if ((int)energyCollected > 0)
			collection += (int)energyCollected + " energy\n";
		c.AddEnergy ((int)energyCollected);
		energyCollected -= (int)energyCollected;

		if ((int)moraleCollected > 0)
			collection += (int)moraleCollected + " morale\n";
		c.AddMorale ((int)moraleCollected);
		moraleCollected -= (int)moraleCollected;

		lastCollection = getTimestamp ();
		updateCollection ();
		c.Save ();

		return collection;
	}

	public bool IsLocked() {
		return locked;
	}

	public void setCoordinates (int x, int y) {
		this.x = x;
		this.y = y;
	}

	public int getX() {
		return x;
	}

	public int getY() {
		return y;
	}

	public HashSet<int> getUnlockSet() {
		HashSet<int> set = new HashSet<int> ();
		foreach (int s in placeUnlockTypes) {
			set.Add(s);	
		}
		return set;
	}
	private int getTimestamp(){
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		int timestamp = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		return timestamp;
	}
	private void updateCollection() {
		List<StoredBuilding> buildingList = GameControl.control.GetBuildings ();
		for (int i=0; i<buildingList.Count; i++) {
			StoredBuilding b = buildingList[i];
			if (b.compare(new StoredBuilding(this))) {
				buildingList[i].lastCollection = this.lastCollection;
				//print ("Updating resource collection time");
			}
		}
		GameControl.control.SetBuildings (buildingList);
		GameControl.control.Save ();
	}
}
