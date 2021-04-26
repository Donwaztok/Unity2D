using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Fields
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] Sprite[] hitSprites;

	// Cached References
	Level level;

	// State
	[SerializeField] int timeHit;

	private void Start() {
		this.level = FindObjectOfType<Level>();
		if (tag.Equals("Breakable")) {
			this.level.CountBlocks();
		}
	}

	private void ShowNextHitSprite() {
		int spriteIndex = this.timeHit - 1;
		if (hitSprites[spriteIndex] != null)
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		else
			Debug.LogError("Block sprite is missing from array " + gameObject.name);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (tag.Equals("Breakable")) {
			timeHit++;
			int maxHits = hitSprites.Length + 1;
			if (timeHit >= maxHits) {
				FindObjectOfType<GameSession>().AddToScore();
				AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
				Destroy(gameObject);
				this.level.OnDestroyBlock();
				this.TriggerSparklesVFX();
			} else {
				ShowNextHitSprite();
			}
		}
	}

	private void TriggerSparklesVFX() {
		GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
		Destroy(sparkles, 1);
	}
}
