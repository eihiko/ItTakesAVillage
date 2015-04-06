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

	public bool HaveResources(GameControl controller) {
		if (controller == null) {
			Debug.Log("No controller");
			return false;
		}
		return (stoneCost <= controller.GetStone () && coinCost <= controller.GetCoin () && foodCost <= controller.GetFood ()
						&& silkCost <= controller.GetSilk () && lumberCost <= controller.GetLumber () &&
						energyCost <= controller.GetEnergy() && moraleCost <= controller.GetMorale ());
	}

	public bool SpendResources(GameControl controller) {
		if (!HaveResources (controller))
						return false;
		controller.UseStone (stoneCost);
		controller.UseCoin (coinCost);
		controller.UseFood (foodCost);
		controller.UseSilk (silkCost);
		controller.UseLumber (lumberCost);
		controller.UseEnergy (energyCost);
		controller.UseMorale (moraleCost);
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
