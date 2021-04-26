using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Condig
	[SerializeField] float minX = 1;
	[SerializeField] float maxX = 15;
	[SerializeField] float screenWidthUnits = 16;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		float mousePosX = Input.mousePosition.x / Screen.width * screenWidthUnits;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(mousePosX, minX, maxX);
		transform.position = paddlePos;
	}
}
