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

	public bool locked; //we may want to replace this with something better

	// Use this for initialization
	void Start () {
	
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
	
	// Update is called once per frame
	void Update () {
		stoneCollected += Time.deltaTime/60 * stoneCollectRate;
		coinCollected += Time.deltaTime/60 * coinCollectRate;
		foodCollected += Time.deltaTime/60 * foodCollectRate;
		silkCollected += Time.deltaTime/60 * silkCollectRate;
		lumberCollected += Time.deltaTime/60 * lumberCollectRate;
		energyCollected += Time.deltaTime/60 * energyCollectRate;
		moraleCollected += Time.deltaTime/60 * moraleCollectRate;
	}

	public void CollectResources() {
		Debug.Log ("Collecting resources");
		GameControl c = GameControl.control;

		c.AddStone ((int)stoneCollected);
		stoneCollected -= (int)stoneCollected;

		c.AddCoin ((int)coinCollected);
		coinCollected -= (int)coinCollected;

		c.AddFood ((int)foodCollected);
		foodCollected -= (int)foodCollected;

		c.AddSilk ((int)silkCollected);
		silkCollected -= (int)silkCollected;

		c.AddLumber ((int)lumberCollected);
		lumberCollected -= (int)lumberCollected;

		c.AddEnergy ((int)energyCollected);
		energyCollected -= (int)energyCollected;

		c.AddMorale ((int)moraleCollected);
		moraleCollected -= (int)moraleCollected;
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
}
