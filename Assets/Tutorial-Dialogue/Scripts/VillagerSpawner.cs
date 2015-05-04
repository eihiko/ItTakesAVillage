using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerSpawner : MonoBehaviour {

	public VillagerDialogue[] npcPrefabs;
	public Transform[] spawnPoints;
	public int villagersToSpawn;
	public int numHouses;
	public Canvas[] dialogues;
	public Canvas[] responses;
	public Canvas endDialogue;
	public VillagerManager manager;

	// Use this for initialization
	void Start () {
		for(int i=0;i<villagersToSpawn;i++) {
			SpawnVillager();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(numHouses>villagersToSpawn) {
			SpawnVillager();
			villagersToSpawn++;
		}
	}
	
	//Spawns a villager with a random dialogue at a random spawn point
	public void SpawnVillager() {
		Vector3 spawn = spawnPoints[Random.Range(0,spawnPoints.Length-1)].transform.localPosition;
		int prefab = Random.Range(0,spawnPoints.Length-1);
		VillagerDialogue npc = npcPrefabs[prefab];
		VillagerDialogue villager = Instantiate(npc) as VillagerDialogue;
		villager.gameObject.transform.localPosition = spawn;
		villager.prefab = prefab;
		int index = Random.Range(0,dialogues.Length-1);
		villager.currentDialogue = dialogues[index];
		//villager.currentDialogue.renderMode = RenderMode.ScreenSpaceOverlay;
		villager.currentDialogue.enabled = false;
		villager.response = responses[index];
		villager.response.enabled = false;
		villager.endDialogue = endDialogue;
		villager.endDialogue.enabled = false;
		villager.dialogueNum = index;
		manager.AddVillager(villager);
		villager.manager = manager;
	}
	
	//Unfinished: Need to work with saving
	public void Respawn(int prefab, int dialogue, bool helped) {
		Vector3 spawn = spawnPoints[Random.Range(0,spawnPoints.Length-1)].transform.localPosition;
		VillagerDialogue npc = npcPrefabs[prefab];
		VillagerDialogue villager = Instantiate(npc) as VillagerDialogue;
		villager.gameObject.transform.localPosition = spawn;
		villager.prefab = prefab;
		villager.response = responses[dialogue];
		villager.endDialogue = endDialogue;
		if(helped) {
			villager.currentDialogue = endDialogue;
		}
		else {
			villager.currentDialogue = dialogues[dialogue];
		}
	}
}
