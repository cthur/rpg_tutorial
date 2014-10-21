using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {

	public enum State {
		Idle,
		Initialize,
		Setup,
		SpawnMob
	}

	public GameObject[] mobPrefabs;              // An array to hold all of the prefabs of mobs that are spawned
	public GameObject[] spawnPoints;             // This array will hold a reference to all of the spawnpoints in the scene

	public State state;                          // This is a local variable that holds the current state

	void Awake () {
		state = State.Initialize;
	}

	// Use this for initialization
	IEnumerator Start () {
		while(true) {
			switch(state) {
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnMob:
				SpawnMob();
				break;

			}

			yield return 0;
		}
	}

	private void Initialize() {
		Debug.Log ("***We are in the Initialize function***");

		if(!CheckForMobPrefabs()) {
			return;
		} 

		if(!CheckForSpawnPoints()) {
			return;
		}

		state = State.Setup;
	}

	private void Setup() {
		Debug.Log ("***We are in the Setup function***");

		state = State.SpawnMob;
	}

	private void SpawnMob() {
		Debug.Log ("***Spawn Mob***");

		GameObject[] gos = AvailableSpawnPoints();

		for(int cnt = 0; cnt < gos.Length; cnt++) {
			GameObject go = Instantiate (	
			                             	mobPrefabs[Random.Range(0, mobPrefabs.Length)],
			                             	gos[cnt].transform.position,
		                             	 	Quaternion.identity
			                             ) as GameObject;
			go.transform.parent = gos[cnt].transform;
		}

		state = State.Idle;
	}

	// Check to see that there is at least one mob prefab to spawn
	private bool CheckForMobPrefabs() {
		if(mobPrefabs.Length > 0) {
			return true;
		} else {
			return false;
		}
	}

	// Check to see if there is at least one spawn point to spawn mobs
	private bool CheckForSpawnPoints() {
		if(spawnPoints.Length > 0) {
			return true;
		} else {
			return false;
		}
	}

	// Generate a list of available spawnpoints that do not have any mobs childed to it
	private GameObject[] AvailableSpawnPoints() {
		List<GameObject> gos = new List<GameObject>();

		for(int cnt = 0; cnt < spawnPoints.Length; cnt++) {
			if(spawnPoints[cnt].transform.childCount == 0) {
				Debug.Log("*** Spawn Point Available ***");
				gos.Add(spawnPoints[cnt]);
			};
		}

		return gos.ToArray();
	}
}
