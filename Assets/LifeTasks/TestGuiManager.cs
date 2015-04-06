using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestGuiManager : MonoBehaviour {

	public Text stone;
	public Text coin;
	public Text food;
	public Text silk;
	public Text lumber;
	public Text morale;
	public Text energy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		stone.text = "Stone: " + GameControl.control.GetStone();
		coin.text = "Coin: " + GameControl.control.GetCoin();
		food.text = "Food: " + GameControl.control.GetFood();
		silk.text = "Silk: " + GameControl.control.GetSilk();
		lumber.text = "Lumber: " + GameControl.control.GetLumber();
		morale.text = "Morale " + GameControl.control.GetMorale();
		energy.text = "Energy " + GameControl.control.GetEnergy();
	}
}
