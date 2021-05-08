using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float health = 100;
	[SerializeField] float shotCounter;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 3;
	[SerializeField] float projectileSpeed = 2;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] GameObject deathVFX;
	[SerializeField] float durationExplosion = 1;
	[SerializeField] AudioClip deathSFX;
	[SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
	[SerializeField] AudioClip shootSFX;
	[SerializeField] [Range(0, 1)] float shootSFXVolume = 0.25f;

	// Start is called before the first frame update
	void Start() {
		shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}

	// Update is called once per frame
	void Update() {
		CountDownAndShoot();
	}

	private void CountDownAndShoot() {
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0) {
			Fire();
			shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire() {
		GameObject laser = Instantiate(
			laserPrefab,
			transform.position,
			Quaternion.identity
		) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if (!damageDealer) return;
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer) {
		this.health -= damageDealer.GetDamage();
		damageDealer.Hit();
		if (this.health <= 0) {
			Die();
		}
	}

	private void Die() {
		Destroy(gameObject);
		GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
		Destroy(explosion, durationExplosion);
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
	}
}
