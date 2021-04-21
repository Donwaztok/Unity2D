using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGame : MonoBehaviour {
	[SerializeField] Text textComponent;
	[SerializeField] State startingState;

	State state;

	// Start is called before the first frame update
	void Start() {
		this.state = this.startingState;
		this.textComponent.text = this.state.GetStateStory();
	}

	// Update is called once per frame
	void Update() {
		ManageState();
	}

	private void ManageState() {
		State[] nextStates = this.state.GetNextStates();
		for (int i = 0; i < nextStates.Length; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
				this.state = nextStates[1];
			}
		}
		this.textComponent.text = this.state.GetStateStory();
	}
}