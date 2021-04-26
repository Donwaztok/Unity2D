using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	// Config
	[SerializeField] int breakableBlocks;

	// Reference
	SceneLoader sceneLoader;

	private void Start() {
		this.sceneLoader = GetComponent<SceneLoader>();
	}

	public void CountBlocks() {
		this.breakableBlocks++;
	}

	public void OnDestroyBlock() {
		this.breakableBlocks--;
		if (this.breakableBlocks <= 0) {
            this.sceneLoader.LoadNextScene();
		}
	}
}
