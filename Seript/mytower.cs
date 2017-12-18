using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mytower : MonoBehaviour {
	
	public GameObject EnemyList;
	public float ShootDelaySeconds = 1;//射擊頻率
	public GameObject CurrentTarget;//當前射擊目標
	public gameSystem Select;
	float _lastShotTime;
	float distance;
	public float power=10;
	public static int Cost = 50;
	public float attrange = 5;


	// Use this for initialization
	void Start () {
		_lastShotTime = Time.time;
		EnemyList = GameObject.Find("make_emeny");
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentTarget == null){
			CurrentTarget = FindEnemy();
		}
		if (CurrentTarget != null ){
			//att and check
			attecter();
			posupdate();
		}
	}
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
	void attecter(){
		var now = Time.time;
		var delay = now - _lastShotTime;
		if (delay < ShootDelaySeconds) {
			// still on cooldown
			return;
		}
		CurrentTarget.GetComponent<Enemy>().Damage(power);
		_lastShotTime = now;
	}
	void posupdate(){
		distance = (CurrentTarget.transform.position - gameObject.transform.position).magnitude;
		if(distance > attrange)
			CurrentTarget = null;
	}
	void OnMouseDown()
	{
		Select = gameObject.GetComponentInParent<gameSystem>();
		Select.hightlight(gameObject);
	}
}
