using UnityEngine;
using System.Collections;

public class VillagerSpawner : MonoBehaviour {

	public VillagerDialogue[] npcPrefabs;
	public Transform[] spawnPoints;
	public int villagersToSpawn;
	public int numHouses;
	public Canvas[] dialogues;
	public Canvas[] responses;
	public VillagerManager manager;

	// Use this for initialization
	void Start () {
		//Debug.Log (manager.ToString());
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
	
	public void SpawnVillager() {
		Vector3 spawn = spawnPoints[Random.Range(0,spawnPoints.Length-1)].transform.localPosition;
		int prefab = Random.Range(0,spawnPoints.Length-1);
		VillagerDialogue npc = npcPrefabs[prefab];
		VillagerDialogue villager = Instantiate(npc) as VillagerDialogue;
		villager.gameObject.transform.localPosition = spawn;
		villager.prefab = prefab;
		int index = Random.Range(0,dialogues.Length-1);
		villager.currentDialogue = dialogues[index];
		villager.response = responses[index];
		villager.dialogueNum = index;
		manager.AddVillager(villager);
		villager.manager = manager;
	}
	
	//Unfinished: Need to work with Life Task/Journal system
	public void Respawn(int prefab,bool response) {
		Vector3 spawn = spawnPoints[Random.Range(0,spawnPoints.Length-1)].transform.localPosition;
		VillagerDialogue npc = npcPrefabs[prefab];
		VillagerDialogue villager = Instantiate(npc) as VillagerDialogue;
		villager.gameObject.transform.localPosition = spawn;
		villager.prefab = prefab;
	}
}
