using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public GameObject ProjectilePrefab;//子彈
	public float ShootDelaySeconds = 1;//射擊頻率

	public Enemy CurrentTarget;//當前射擊目標 
	float _lastShotTime;

	// Use this for initialization
	void Start () {//檢查有沒有子彈
		if (ProjectilePrefab == null) {
			Debug.LogError("Tower is missing Projectile Prefab", this);
		}
		_lastShotTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// update CurrentTarget
		if (CurrentTarget == null || !CurrentTarget.IsAlive) {//會一直檢查我有沒有目標 
			CurrentTarget = Enemy.FindNextAlive();//會拿到有Alive tag的obj
		}

		if (CurrentTarget != null) {
			RotateTowardTarget ();
			ShootAtTarget ();
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
}
