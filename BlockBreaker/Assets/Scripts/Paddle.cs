using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Condig
	[SerializeField] float minX = 1;
	[SerializeField] float maxX = 15;
	[SerializeField] float screenWidthUnits = 16;

	// References
	GameSession gameSession;
	Ball ball;

	// Start is called before the first frame update
	void Start() {
		this.gameSession = FindObjectOfType<GameSession>();
		this.ball = FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update() {
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
		transform.position = paddlePos;
	}

	private float GetXPos() {
		if (this.gameSession.IsAutoPlayEnabled()) {
			return this.ball.transform.position.x;
		}
		return Input.mousePosition.x / Screen.width * screenWidthUnits;
	}
}
