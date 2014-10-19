using UnityEngine;
using System.Collections;

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

		state = State.Setup;
	}

	private void Setup() {
		Debug.Log ("***We are in the Setup function***");

		state = State.SpawnMob;
	}

	private void SpawnMob() {
		Debug.Log ("***Spawn Mob***");

		state = State.Idle;
	}
}
