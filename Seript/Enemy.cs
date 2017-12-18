using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public class Enemy : MonoBehaviour {
	//掛載物件:emeny
	//調用物件:GameManager、Wave、Projectil、Tower
	//說明:emeny之移動、生命、死亡等等
	public static readonly string AliveTag = "Alive";
	public static readonly string DeadTag = "Dead";
	
	public static Enemy FindNextAlive() {
		var obj =  GameObject.FindGameObjectWithTag(AliveTag);
		if (obj != null) {
			return obj.GetComponent<Enemy> ();//將找到的物件回傳，Tower.Update()會需要一直拿到
		}
		return null;
	}
	
	
	public float MaxHealth = 100;
	public float Health = 100;
	public float MaxDistanceToGoal = .1f;
	public float Speed = 5;
	public int earn = 30;

	public WavePath Path;

	Wave _wave;

	IEnumerator<Transform> _pathIterator;
	
	
	public bool IsAlive {
		get { return Health > 0; }
	}
	
	public void InitEnemy(Wave wave) {
		Debug.Assert (wave != null);
		
		_wave = wave;
		Path = _wave.WaveGenerator.Path;
		
		RestartPath ();
	}
	
	public void Damage(float damage) {
		if (!IsAlive) {
			// don't do anything when dead
			return;
		}		
		Health -= damage;
		
		if (!IsAlive) {
			// died from damage
			OnDeath();
		}
	}

	#region Events
	void OnDeath() {
		tag = DeadTag;
		Health = 0;
		gameObject.transform.parent.GetComponentInParent<gameSystem>().earnmoney(earn);
		Destroy (gameObject);
	}
	
	void OnReachedGoal() {
		// TODO: Enemy arrived at end of path
		var home = gameObject.transform.parent.gameObject.GetComponentInParent<gameSystem>();
		home.treeHealth--;
		home.ShowText();		
		Destroy(gameObject);
		if(home.treeHealth<=0){
			home.endgame("You lose");
		}
	}
	#endregion

	void RestartPath() {
		if (Path != null) {
			_pathIterator = Path.GetPathEnumeratorForward ();//只要叫了_pathIterator 就會給我現在的的目標物件
			_pathIterator.MoveNext ();//下一個子物件
		}
		if(Path == null){
			print ("path not find");
		}
	}

	// Use this for initialization
	void Start () {
		tag = AliveTag;

		RestartPath ();
	}

	// Update is called once per frame
	void Update () {
		if (IsAlive) {
			MoveAlongPath ();
		}
	}


	void MoveAlongPath() {//沿著WavePath設定好的路線移動 會一直拿 路徑子物件的位置來移動
	//print ("_pathIterator.Current:"+_pathIterator.Current);
		if (_pathIterator == null || _pathIterator.Current == null)
			return;
		
			
		
		// move towards current target
		var targetPosition = _pathIterator.Current.position;
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, Time.deltaTime * Speed);
		//朝向目標移動
		// check if we reached target
		var distanceSquared = (transform.position - targetPosition).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) {//快到點了 就指向下一個目標
			// we arrived at current target -> Choose next target
			_pathIterator.MoveNext();
			if (_pathIterator.Current == null) {
				//吃不到這邊
				OnReachedGoal();//已達終點
			}
		}
	}

}
