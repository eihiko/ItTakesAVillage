using UnityEngine;
using System.Collections;

public class VillagerManager : MonoBehaviour {

	private VillagerDialogue[] villagers;
	private bool[] helped;
	private int index;

	// Use this for initialization
	void Start () {
		index = 0;
		villagers = new VillagerDialogue[20];
		helped = new bool[20];
		for (int i=0;i<helped.Length;i++) {
			helped[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddVillager(VillagerDialogue villager) {
		if(index<villagers.Length) {
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
}
