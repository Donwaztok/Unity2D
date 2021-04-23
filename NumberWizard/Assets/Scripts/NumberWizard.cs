using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour {
	[SerializeField] int max;
	[SerializeField] int min;
	[SerializeField] TextMeshProUGUI guessText;
	int guess;

	// Start is called before the first frame update
	void Start() {
		this.NextGuess();
	}

	public void OnPressHigher() {
		this.min = this.guess;
		this.min++;
		this.NextGuess();
	}

	public void OnPressLower() {
		this.max = this.guess;
		this.max--;
		this.NextGuess();
	}

	void NextGuess() {
		this.guess = Random.Range(this.min, this.max + 1);
		this.guessText.text = this.guess.ToString();
	}
}
