using UnityEngine;
using System.Collections;

public class OptionSelection : MonoBehaviour {

	public VillagerDialogue villager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setVillager(VillagerDialogue set) {
		villager = set;
	}
	
	public void select() {
		villager.manager.setHelped(villager);
	}
	
}
