using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

	[SerializeField] GameObject enemyPrefab;
	[SerializeField] GameObject pathPrefab;
	[SerializeField] float timeBetweenSpawns = 0.5f;
	[SerializeField] float spawnRandomFactor = 0.3f;
	[SerializeField] float moveSpeed = 2;
	[SerializeField] int numberOfEnemies = 5;

	public GameObject GetEnemyPrefab() { return this.enemyPrefab; }
	public float GetTimeBetweenSpawns() { return this.timeBetweenSpawns; }
	public float GetSpawnRandomFactor() { return this.spawnRandomFactor; }
	public float GetMoveSpeed() { return this.moveSpeed; }
	public int GetNumberOfEnemies() { return this.numberOfEnemies; }

	public List<Transform> GetWaypoints() {
		var waveWaypoints = new List<Transform>();

		foreach (Transform child in this.pathPrefab.transform) {
			waveWaypoints.Add(child);
		}

		return waveWaypoints;
	}
}
