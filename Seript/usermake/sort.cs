using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sort : MonoBehaviour {
	public GameObject Wavepath;

	public GameObject map;
	public Text savename,wrongmessage;

	bool pathcorrect=false;
	

	public void Dosave(){
		
		GameInfo.mapStr=savename.text;
		print (GameInfo.mapStr+pathcorrect);
		if(savename.text!=""&&pathcorrect){
			string str="";
			for(var i=0;i<16;i++)
				for(int j=0;j<9;j++)
					str+=GameInfo.floors[i,j].ToString();
				
			PlayerPrefs.SetString(savename.text,str);
			GameInfo.menuChoose = savename.text;
			SceneManager.LoadScene("mainMap");
		}
		
	}

	void resetmap(){
		while(gameObject.transform.childCount>0){
			gameObject.transform.GetChild(gameObject.transform.childCount-1).GetComponent<SpriteRenderer>().color = Color.white;
			var pos = gameObject.transform.GetChild(gameObject.transform.childCount-1).GetComponent<floorInfo>();
			gameObject.transform.GetChild(gameObject.transform.childCount-1).parent = map.transform;
			GameInfo.floors[pos.x,pos.y]=0;
			pos.floorSet=0;
			wrongmessage.gameObject.SetActive(true);
		}
		print ("wrong path");
		pathcorrect = false;
	}
	public void checkpath(){
		if(gameObject.transform.childCount>0){
			for(var i=1;i<15;i++)
			for(int j=1;j<8;j++){
				int k=0;
				if(GameInfo.floors[i,j]>0){//上下左右必有0~2 個1，若無則為起始或是結束這邊不檢查
					if(GameInfo.floors[i+1,j]>0){k++;}
					if(GameInfo.floors[i-1,j]>0){k++;}
					if(GameInfo.floors[i,j+1]>0){k++;}
					if(GameInfo.floors[i,j-1]>0){k++;}//k=4為十字路口 k=3為T字路口 k=2 為一般道路
					if(k<2){GameInfo.floors[i,j]=0;}//不是道路
					else if(k==2){GameInfo.floors[i,j]=1;}
					else if(k==4){GameInfo.floors[i,j]=2;}
					else{
						resetmap();
						return ;
					}
				}
			}
			int side=0;
			for(int i =0;i<gameObject.transform.childCount;i++){
				if(gameObject.transform.GetChild(i).GetComponent<floorInfo>().floorSet==9){//檢查起始與結束
					side++;
				}
			}
			if(side!=2){
				resetmap();
				return ;
			}

			while(gameObject.transform.childCount>0){
				int i = gameObject.transform.childCount-1;
				var a = gameObject.transform.GetChild(i).GetComponent<floorInfo>();
				if(a.floorSet==9){
					gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
					gameObject.transform.GetChild(i).GetComponent<floorInfo>().floorSet=9;
					GameInfo.floors[a.x,a.y]=9;
					gameObject.transform.GetChild(i).name="sidepath";
					gameObject.transform.GetChild(i).parent = Wavepath.transform;

				}
				else if(GameInfo.floors[a.x,a.y]==0){
					gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
					gameObject.transform.GetChild(i).GetComponent<floorInfo>().floorSet=0;
					gameObject.transform.GetChild(i).parent = map.transform;
				}
				else if(GameInfo.floors[a.x,a.y]==1){
					gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
					gameObject.transform.GetChild(i).GetComponent<floorInfo>().floorSet=1;
					gameObject.transform.GetChild(i).name="path";
					gameObject.transform.GetChild(i).parent = Wavepath.transform;
				}
				else if(GameInfo.floors[a.x,a.y]==2){
					gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.green;
					gameObject.transform.GetChild(i).GetComponent<floorInfo>().floorSet=2;
					gameObject.transform.GetChild(i).name="path4";
					gameObject.transform.GetChild(i).parent = Wavepath.transform;
				}

			}
			string str="";
			for(var i=0;i<16;i++)
				for(int j=0;j<9;j++){
					str+=GameInfo.floors[i,j].ToString();
				}
			pathcorrect = true;
			}
		
	}


}
