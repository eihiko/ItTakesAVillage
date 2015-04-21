using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

	public VillagerDialogue[] villagers;
	private bool[] helped;
	private int index;
	public VillagerSpawner spawner;

	// Use this for initialization
	void Start () {
		villagers = new VillagerDialogue[20];
		index = 0;
		helped = new bool[20];
		for (int i=0;i<helped.Length;i++) {
			helped[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddVillager(VillagerDialogue villager) {
		//Debug.Log(villager.ToString());
		//Debug.Log(villagers.ToString());
		if(index < villagers.Length) {
			villagers[index] = villager;
			villager.idnum = index;
			index++;
		}
		else {
			VillagerDialogue[] temp = new VillagerDialogue[villagers.Length*2];
			bool[] bools = new bool[helped.Length*2];
			villagers.CopyTo(temp,0);
			villagers = temp;
			helped.CopyTo(bools,0);
			helped = bools;
			for (int i=index;i<helped.Length;i++) {
				helped[i] = false;
			}
			AddVillager(villager);
		}
	}
	
	public void setHelped(VillagerDialogue villager) {
		helped[villager.idnum] = true;
		villager.Test();
	}
	
	//Unfinished: Need to work with Life Task/Journal system
	public void Save() {
	}
	
	public void Load() {
		//Retrieve list of villagers and whether they were helped, then Respawn them.
	}
}
