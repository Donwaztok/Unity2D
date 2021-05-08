using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

	[SerializeField] float backgroundScrollSpeed = 0.5f;

	Material myMaterial;
	Vector2 offset;

	// Start is called before the first frame update
	void Start() {
		this.myMaterial = GetComponent<Renderer>().material;
		this.offset = new Vector2(0, backgroundScrollSpeed);
	}

	// Update is called once per frame
	void Update() {
        this.myMaterial.mainTextureOffset += this.offset * Time.deltaTime;
	}
}
