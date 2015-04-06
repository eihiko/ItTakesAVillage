using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceGUI : MonoBehaviour {
	public Text stone, coin, food, silk, lumber, energy, morale;
	
	// Update is called once per frame
	void Update () {
		GameControl c = GameControl.control;
		stone.text = "Stone: "+ c.GetStone();
		coin.text = "Coin: " + c.GetCoin();
		food.text = "Food: " + c.GetFood();
		silk.text = "Silk: " + c.GetSilk();
		lumber.text = "Lumber: " + c.GetLumber();
		energy.text = "Energy: " + c.GetEnergy();
		morale.text = "Morale: " + c.GetMorale();
	}
}
