using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	//掛載物件:Tower
	//調用物件:null
	//說明:塔座之射擊
	public GameObject ProjectilePrefab;//子彈
	public GameObject EnemyList;
	public float ShootDelaySeconds = 1;//射擊頻率

	public Enemy CurrentTarget;//當前射擊目標 
	public gameSystem Select;
	float _lastShotTime;
	float distance;

	public float attrange = 5;

	// Use this for initialization
	void Start () {//檢查有沒有子彈
		if (ProjectilePrefab == null) {
			Debug.LogError("Tower is missing Projectile Prefab", this);
		}
		_lastShotTime = Time.time;
		EnemyList = GameObject.Find("make_emeny");
	}
	
	// Update is called once per frame
	void Update () {
		// update CurrentTarget
		if (CurrentTarget == null || !CurrentTarget.IsAlive) {//會一直檢查我有沒有目標 
			CurrentTarget = Enemy.FindNextAlive();//會拿到有Alive tag的obj
			//print ("finding");
		}

		if (CurrentTarget != null ) {
				RotateTowardTarget ();
				ShootAtTarget ();
				//print ("in loop");
			//attecter();
			//range();
		}
	}

	void RotateTowardTarget() {//應該是計算角度
		Vector3 targetDir = CurrentTarget.transform.position - transform.position;//算出位置差據
		//float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100, 0.0F);//旋轉角度,轉向(向量)
		Debug.DrawRay(transform.position, newDir, Color.red);//畫出輔助線 ps 應該是紅色那條
		//transform.LookAt (CurrentTarget.transform.position);
	}

	void ShootAtTarget() {
		if (ProjectilePrefab == null) {
			return;
		}
		var now = Time.time;
		var delay = now - _lastShotTime;
		if (delay < ShootDelaySeconds) {
			// still on cooldown
			return;
		}

		// shoot a new projectile ,射出子彈
		var go = (GameObject)Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        go.transform.parent = gameObject.transform;//做為塔的子物件
        var projectile = go.GetComponent<Projectile> ();
		var rigidBody = go.GetComponent<Rigidbody2D> ();
		var direction = CurrentTarget.transform.position - go.transform.position;
		direction.Normalize ();//使向量大小為 1

		rigidBody.velocity = direction * projectile.Speed;

		_lastShotTime = now;
	}

	void OnMouseDown()
	{
		//print (gameObject.name);
		Select = gameObject.GetComponentInParent<gameSystem>();
		Select.hightlight(gameObject);
	}
	void attecter(){
		var now = Time.time;
		var delay = now - _lastShotTime;
		if (delay < ShootDelaySeconds) {
			// still on cooldown
			return;
		}
		CurrentTarget.Health=CurrentTarget.Health-50;
	}
	/*
	bool range(){
		//Vector3 r = CurrentTarget.transform.position -gameObject.transform.position;
		distance = (CurrentTarget.transform.position - gameObject.transform.position).magnitude;
		//print (distance);
		if (distance< attrange)
			return true;
		else{
			CurrentTarget = Enemy.FindNextAlive();
			//CurrentTarget = null;
			print ("next");
			return false;
		}	
	}
	*/
	GameObject FindEnemy(){
		for(int i =0;i<EnemyList.transform.childCount;i++){
			var obj =EnemyList.transform.GetChild(i);
			distance = (obj.position - gameObject.transform.position).magnitude;
			if(distance< attrange)
				//print (obj.gameObject);
				return obj.gameObject;
		}
		return null;
	}
}
