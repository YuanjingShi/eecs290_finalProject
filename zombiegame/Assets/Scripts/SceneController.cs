﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	private bool first_round = true;

	void OnGUI() {
		if (_enemy == null &&!first_round) {
			var style = new GUIStyle("label");
			style.fontSize = 80;
			GUI.Label(new Rect (Screen.width / 2, Screen.height, 150, 25), "<size=40>Lose</size>");
//			GUI.Label (Rect(9, 30, 500, 20), "Congratulations! You have saved Earth from the Zombie Apocalypse!", style); 
			if (GUI.Button (new Rect (Screen.width / 2, 3*Screen.height / 4, 150, 25), "Start Game")) {
				SceneManager.LoadScene("Scene") ;
			}
			if (GUI.Button (new Rect (Screen.width / 2, 3*Screen.height / 4 + 25, 150, 25), "End Game")) {
				Application.Quit();
			}
		}
	}

	void Update() {
		if (_enemy == null && first_round) {
			
			first_round = false;

			for (int i = -5; i < 5; i++) {
				_enemy = Instantiate (enemyPrefab) as GameObject;
				_enemy.transform.position = new Vector3 (287.1f + i*2, 1.5f, 870);
				float angle = Random.Range (0, 360);
				_enemy.transform.Rotate (0, angle, 0);
				_enemy.GetComponent<WanderingAI> ().SetAlive (true);
			}

		}
	}
}
