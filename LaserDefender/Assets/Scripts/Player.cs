using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Params
	[SerializeField] float moveSpeed = 10;
	[SerializeField] float padding = 1;
	[SerializeField] float projectileSpeed = 10;
	[SerializeField] float projectileFiringPeriod = 0.1f;
	[SerializeField] GameObject laserPrefab;

	// State
	float xMin;
	float xMax;
	float yMin;
	float yMax;
	Coroutine firingCoroutine;

	// Start is called before the first frame update
	void Start() {
		SetUpMoveBoundaries();
	}

	// Update is called once per frame
	void Update() {
		Move();
		Fire();
	}

	private void Move() {
		float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		float newXPos = Mathf.Clamp(transform.position.x + deltaX, this.xMin, this.xMax);
		float newYPos = Mathf.Clamp(transform.position.y + deltaY, this.yMin, this.yMax);
		transform.position = new Vector2(newXPos, newYPos);
	}

	private void Fire() {
		if (Input.GetButtonDown("Fire1")) {
			firingCoroutine = StartCoroutine(FireContinuously());
		}
		if (Input.GetButtonUp("Fire1")) {
			StopCoroutine(firingCoroutine);
		}
	}

	IEnumerator FireContinuously() {
		while (true) {
			GameObject laser = Instantiate(
							laserPrefab,
							transform.position,
							Quaternion.identity
						) as GameObject;
			laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
			yield return new WaitForSeconds(projectileFiringPeriod);
		}
	}

	private void SetUpMoveBoundaries() {
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + this.padding;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - this.padding;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + this.padding;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - this.padding;
	}

}
