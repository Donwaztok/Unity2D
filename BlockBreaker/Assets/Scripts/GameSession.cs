using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour {

	// Params
	[Range(0.1f, 10)] [SerializeField] float gameSpeed = 1;
	[SerializeField] int scorePerBlock = 83;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] bool isAutoPlayEnabled;

	// State
	[SerializeField] int currentScore = 0;

	private void Awake() {
		int gameStatusCount = FindObjectsOfType<GameSession>().Length;
		if (gameStatusCount > 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

	// Update is called once per frame
	void Update() {
		Time.timeScale = gameSpeed;
	}

	public void AddToScore() {
		this.currentScore += this.scorePerBlock;
		this.scoreText.text = this.currentScore.ToString();
	}

	internal bool IsAutoPlayEnabled() {
		return this.isAutoPlayEnabled;
	}

	public void ResetGame(){
        Destroy(gameObject);
    }
}
