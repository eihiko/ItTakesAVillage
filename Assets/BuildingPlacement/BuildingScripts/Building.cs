using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	public Vector2 size; //how many squares it takes up
	public int stoneCost;
	public int coinCost;
	public int foodCost;
	public int silkCost;
	public int lumberCost;
	public int energyCost;
	public int moraleCost;

	public int buildingType;
	private int x;
	private int y;

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
	
	// Update is called once per frame
	void Update () {
	
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

}
