using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Configs
	[SerializeField] Paddle paddle1;
	[SerializeField] float xPush = 2;
	[SerializeField] float yPush = 15;
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float randomFactor = 0.2f;

	// State
	Vector2 paddleToBallVector;
	bool hasStarted = false;

	// Cached
	AudioSource myAudioSource;
	Rigidbody2D myRigidbody2D;

	// Start is called before the first frame update
	void Start() {
		this.paddleToBallVector = transform.position - this.paddle1.transform.position;
		this.myAudioSource = GetComponent<AudioSource>();
		this.myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		if (!this.hasStarted) {
			LockBallToPaddle();
			LauchOnMouseClick();
		}
	}

	private void LockBallToPaddle() {
		Vector2 paddlePos = new Vector2(this.paddle1.transform.position.x, this.paddle1.transform.position.y);
		transform.position = paddlePos + this.paddleToBallVector;
	}

	private void LauchOnMouseClick() {
		if (Input.GetMouseButtonDown(0)) {
			this.hasStarted = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2(this.xPush, this.yPush);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		Vector2 velocityTweak = new Vector2(Random.Range(0, this.randomFactor), Random.Range(0, this.randomFactor));
		if (this.hasStarted) {
			AudioClip clip = this.ballSounds[Random.Range(0, this.ballSounds.Length)];
			this.myAudioSource.PlayOneShot(clip);
			this.myRigidbody2D.velocity += velocityTweak;
		}
	}
}
