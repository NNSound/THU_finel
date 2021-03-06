﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveGenerator : MonoBehaviour {
	//掛載物件:make_emeny
	//調用物件:Enemy、GameManager、Wave
	//說明:動態生產Emeny，控制產出時間、間隔、數量、波數。
	/// <summary>
	/// Time between waves in seconds.
	/// </summary>
	public GameObject[] emelist;
	public float DelayBetweenWaves = 30;

	public WavePath Path;
	
	public WaveTemplate[] WaveTemplates;

	public Text InfoText;

	List<Wave> _waves;

	float _lastUpdate;
	
	//public setText setText;

	public Wave CurrentWave {
		get {
			return _waves.LastOrDefault();
		}
	}

	public int CurrentWaveNumber {
		
		get {			
			return _waves.Count+1;
		}
	}

	/// <summary>
	/// The enemy template of the next wave (following the current wave)
	/// </summary>
	public WaveTemplate NextWaveTemplate {
		get {
			if (WaveTemplates.Length <= _waves.Count) {
				GetComponentInParent<gameSystem>().endgame("You Won");
				// already spawned all waves
				return null;
			}
			//print (WaveTemplates[_waves.Count]);
			return WaveTemplates[_waves.Count];
		}
	}

	public bool HasMoreWaves {
		get {
			return NextWaveTemplate != null;
		}
	}

	void ShowText(string text) {
		if (InfoText != null) {
			InfoText.text = text;
		}
	}
	public void setTemples(){
		//WaveTemplates = new WaveTemplate[1];

		
		/*	
		print (WaveTemplates.Length);
		var i = WaveTemplates[0].Amount;
		var j = WaveTemplates[0].DelayBetweenEnemies;
		var k = WaveTemplates[0].EnemyPrefab;
		print (i);
		*/
		//int[,] arr = {{1,0,2},{2,1,5},{5,0,10},{1,0,10},{2,1,5}};
		for(int i=0;i<WaveTemplates.Length;i++){
			WaveTemplates[i].DelayBetweenEnemies=1f;
			WaveTemplates[i].EnemyPrefab = emelist[0];
			WaveTemplates[i].Amount = (i+1)*5;
		}

		
	}
	// Use this for initialization
	void Start () {
		
		//setTemples();
		if (WaveTemplates == null || WaveTemplates.Length == 0) {
			Debug.LogError("WaveTemplates are empty");
		}
		if (WaveTemplates == null || WaveTemplates.Length == 0) {
			Debug.LogError("WavePath is not set");
		}

		_waves = new List<Wave> ();
		ResetTimer ();
	}
	
	// Update is called once per frame
	void Update () {

		// update all currently running waves
		foreach (var wave in _waves) {
			wave.Update();
		}

		// check if we need to spawn another wave
		if (HasMoreWaves) {
			UpdateWaveProgress ();
		} else {
			ShowText("Last Wave!");
		}
	}

	void UpdateWaveProgress() {
		if(gameObject.transform.childCount>0)
				return;
		var now = Time.time;
		var timeSinceLastUpdate = now - _lastUpdate;

		ShowText("Next wave: " + CurrentWaveNumber + "/"+WaveTemplates.Length);
		if (timeSinceLastUpdate >= DelayBetweenWaves) {			
			StartNextWave ();
		}
	}
	
	public void ResetTimer() {
		// reset timer
		_lastUpdate = Time.time;
	}
	
	// start next wave
	public void StartNextWave() {
		if (NextWaveTemplate == null) {
			// all waves done!
			GameManager.Instance.OnLastWave();
			return;
		}

		// create new wave
		var wave = new Wave (this);
		wave.WaveTemplate = NextWaveTemplate;
		_waves.Add (wave);	

		// spawn first enemy in new wave
		wave.Start ();

		ResetTimer ();
	}
	
	// start next enemy of given wave
	public void SpawnNextEnemy(Wave wave) {
		var enemyObject = Instantiate (wave.WaveTemplate.EnemyPrefab);
		enemyObject.transform.parent = gameObject.transform;
		var enemy = enemyObject.GetComponent<Enemy> ();
		enemy.InitEnemy (wave);
		wave.Enemies.Add (enemy);
		
		// move enemy to starting position
		enemy.transform.position = Path.FirstPoint.position;
	}

}
