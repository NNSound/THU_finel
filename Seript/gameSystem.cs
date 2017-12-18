using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameSystem : MonoBehaviour {
	//掛載物件:Map
	//調用物件:ground_squire_obj(Clone)<make_tower_mouse>、tower_white<Button>、tower_red<Button>、tower_pup<Button>、tower_blk<Button、
	//說明:存放副程式以方便Button調用與維護

	public mytower mytower;
	public GameObject Makepanel;
	private GameObject floor;
	public GameObject isSelect;
	public GameObject endCanvas;
	public int treeHealth = 20;
	
	//public make_tower_mouse mtm;
	public Text CoinText;
	public int coin=100;
	
 	
	public bool makeTowerPanel(GameObject obj){
		//print ("makeTowerPanel");
		Makepanel.gameObject.SetActive(true);
		floor = obj;
		return true;
	}
	public void makeTower(GameObject tower){//btn 呼叫的
			mytower = tower.GetComponent<mytower>();
			if(coin < mytower.Cost){//錢不夠
				return;
			}
			coin = coin - mytower.Cost;
			Vector3 me = floor.transform.position;
            GameObject childTower =  Instantiate(tower, me, transform.rotation);
            childTower.transform.parent = floor.transform;
			ShowText();
			Makepanel.gameObject.SetActive(false);

	}
	public void earnmoney(int earn){
		coin = coin +earn;
		ShowText();

	}
	public void hightlight(GameObject obj){		
		if(isSelect == obj){
			isSelect.transform.GetChild(0).gameObject.SetActive(false);
			isSelect = null;
			return;
		}
		if(isSelect !=null )
			isSelect.transform.GetChild(0).gameObject.SetActive(false);		
		isSelect = obj;
		obj.transform.GetChild(0).gameObject.SetActive(true);
	}	
	public void ShowText() {
		if (CoinText != null) {
			CoinText.text = "Coin : "+coin+" Health:"+treeHealth+"/20";
		}
	}
	public void endgame(string text){
		Time.timeScale = 0f;
		endCanvas.SetActive(true);
		print (text);
	}
	
	
	
}
