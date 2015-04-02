using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour {
	public Text stone, coin, food, silk, lumber, energy, morale;

	public GameControl controller;
	
	// Update is called once per frame
	void Update () {
		stone.text = "Stone: "+controller.GetStone();
		coin.text = "Coin: "+controller.GetCoin();
		food.text = "Food: "+controller.GetFood();
		silk.text = "Silk: "+controller.GetSilk();
		lumber.text = "Lumber: "+controller.GetLumber();
		energy.text = "Energy: "+controller.GetEnergy();
		morale.text = "Morale: "+controller.GetMorale();
	}
}
