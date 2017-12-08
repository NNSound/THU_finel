using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sort : MonoBehaviour {
	public GameObject Wavepath;
	public GameObject floorObj;
	public Text savename;
	
	int nameIndex =0;
	
	public void Pathsort(){
		if(gameObject.transform.childCount >0){			
			var index = gameObject.transform.GetChild(0);
			index.name="path"+nameIndex;
			nameIndex++;
			index.transform.parent = Wavepath.transform;
			var getXY = index.GetComponent<floorInfo>();
			if(Wavepath.transform.childCount>0)
				GameInfo.floors[getXY.x,getXY.y]=1;
			else
				GameInfo.floors[getXY.x,getXY.y]=9;
			int i=0;
			while(gameObject.transform.childCount >0){
				if(i > gameObject.transform.childCount-1){
					print ("break");
					break;
				}
				else if((index.transform.position - gameObject.transform.GetChild(i).transform.position).magnitude<1.1){//
					print (gameObject.transform.GetChild(i).name );
					gameObject.transform.GetChild(i).name = "pathsort"+nameIndex;
					nameIndex++;
					index = gameObject.transform.GetChild(i);
					index.transform.parent = Wavepath.transform;
					getXY = index.GetComponent<floorInfo>();
					i=0;
					GameInfo.floors[getXY.x,getXY.y]=1;
					continue;
				}
				i++;
			}
		}
	}
	public void showarr(){
		for(var i=0;i<16;i++)
			for(int j=0;j<9;j++)
				print (GameInfo.floors[i,j]);
	}
	public void Dosave(){
		string str=null;
		for(var i=0;i<16;i++)
			for(int j=0;j<9;j++){
				str+=GameInfo.floors[i,j].ToString();
			}
		GameInfo.mapStr=str;
		
		if(savename.text!=null){
			PlayerPrefs.SetString(savename.text,GameInfo.mapStr);
			GameInfo.menuChoose = savename.text;
		}			
		print (savename.text);
	}
	public void DoLoad(){
		var str = PlayerPrefs.GetString("mapinfo");
		//print (str.Length);
		int len=0;
		var loadmap = new GameObject();
		loadmap.name = "loadmap";
		for(var i=0;i<16;i++)
			for(int j=0;j<9;j++){
				var a = str.Substring(i*9+j,1);
				var setGround = new Vector3(-7.5f+i, -4f+j, 0);				
				if(a.Equals("1")){
					GameObject newfloor =  Instantiate(floorObj, setGround, transform.rotation);
                	newfloor.transform.parent = gameObject.transform;
                	newfloor.AddComponent<makePath>();
                	newfloor.AddComponent<BoxCollider2D>();
               		var setpos =newfloor.GetComponent<floorInfo>();
					newfloor.GetComponent<SpriteRenderer>().color = Color.red;
                	setpos.x=i;setpos.y=j;
				}
				else{
					GameObject newfloor =  Instantiate(floorObj, setGround, transform.rotation);
                	newfloor.transform.parent = loadmap.transform;
                	newfloor.AddComponent<makePath>();
                	newfloor.AddComponent<BoxCollider2D>();
                	var setpos =newfloor.GetComponent<floorInfo>();
                	setpos.x=i;setpos.y=j;
				}
					
			}
		//loadmap.transform.localScale= new Vector3(0.8f,0.8f,0);
		 Pathsort();
	}

}
