using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadmap : MonoBehaviour {
	public GameObject [] MapObj=new GameObject[5];
	GameObject Wavepath,path,startpath;
	public GameObject makeEmeny;
	GameObject[,] arrObj=new GameObject[16,9];

	// Use this for initialization
	void Start () {
		//map1-1 , map1-2
		if(GameInfo.menuChoose==null){
			print ("null");
			GameInfo.menuChoose = "test";
		}
		//print (GameInfo.menuChoose);
		var str = PlayerPrefs.GetString(GameInfo.menuChoose);
		print (str);
		//int len=0;
		var loadmap = new GameObject();
		path = new GameObject();
		Wavepath = new GameObject();
		loadmap.name = "loadmap";
		path.name = "path";
		Wavepath.name = "Wavapath";
		loadmap.transform.parent = gameObject.transform;
		path.transform.parent= gameObject.transform;
		Wavepath.transform.parent= gameObject.transform;
		//loadmap.AddComponent<gameSystem>();

		
		for(var i=0;i<16;i++)//make map
			for(int j=0;j<9;j++){
				var a = str.Substring(i*9+j,1);
				var setGround = new Vector3(-7.5f+i, -4f+j, 0);				
				if(a.Equals("1")){//一般道路
					GameObject newfloor =  Instantiate(MapObj[0], setGround, transform.rotation);
					arrObj[i,j]=newfloor;
                	newfloor.transform.parent = path.transform;
					newfloor.AddComponent<floorInfo>();
               		var setpos =newfloor.GetComponent<floorInfo>();
					setpos.floorSet = 1;
                	setpos.x=i;setpos.y=j;
					newfloor.GetComponent<SpriteRenderer>().color = Color.red;
				}
				else if(a.Equals("9")){//起始與結束
					startpath =  Instantiate(MapObj[0], setGround, transform.rotation);
					arrObj[i,j]=startpath;
					startpath.name = "sidepath";
                	startpath.transform.parent = path.transform;
					startpath.AddComponent<floorInfo>();
               		var setpos =startpath.GetComponent<floorInfo>();
					setpos.floorSet = 9;
                	setpos.x=i;setpos.y=j;
					startpath.GetComponent<SpriteRenderer>().color = Color.red;

				}
				else if(a.Equals("2")){//十字路口
					startpath =  Instantiate(MapObj[0], setGround, transform.rotation);
					arrObj[i,j]=startpath;
					startpath.name = "path_X";
                	startpath.transform.parent = path.transform;
					startpath.AddComponent<floorInfo>();
               		var setpos =startpath.GetComponent<floorInfo>();
					setpos.floorSet = 2;
                	setpos.x=i;setpos.y=j;
					startpath.GetComponent<SpriteRenderer>().color = Color.green;

				}
				else{//空地
					GameObject newfloor =  Instantiate(MapObj[0], setGround, transform.rotation);
					arrObj[i,j]=newfloor;
                	newfloor.transform.parent = loadmap.transform;
					newfloor.AddComponent<floorInfo>();
					newfloor.AddComponent<make_tower_mouse>();
					newfloor.AddComponent<BoxCollider2D>();
                	var setpos =newfloor.GetComponent<floorInfo>();
                	setpos.x=i;setpos.y=j;
				}
					
			
		
		}
		transform.localScale= new Vector3(0.9f,0.9f,1);
		loadsort();

		makeEmeny.transform.position = Wavepath.transform.GetChild(0).position;
		Wavepath.AddComponent<WavePath>();
		makeEmeny.GetComponent<WaveGenerator>().Path = Wavepath.GetComponent<WavePath>();
		

	}
	
	// Update is called once per frame
	public void Pathsort(){
		var index =0;
		int pathindex=1;
		var breakindex=0;
		var standard = startpath;
		while (path.transform.childCount>0){
			var obj = path.transform.GetChild(index).gameObject;
			var posxy = obj.GetComponent<floorInfo>();
			var standardxy = standard.GetComponent<floorInfo>();
			int m = Mathf.Abs(standardxy.x-posxy.x);
			int n = Mathf.Abs(standardxy.y-posxy.y);
			if(m==1&&n==0){//posxy 為下個路徑左右
				obj.transform.parent = Wavepath.transform;
				obj.name="path"+pathindex;
				pathindex++;
				standard = obj;
			}
			if(m==0&&n==1){//posxy 為下個路徑上下
				obj.transform.parent = Wavepath.transform;
				obj.name="path"+pathindex;
				pathindex++;
				standard = obj;
			}
			index++;
			breakindex++;
			if(index>path.transform.childCount-1)
				index=0;
			if(breakindex>1000){
				print ("break");
				break;
			}
		}
		Wavepath.AddComponent<WavePath>();
		Destroy(path);
		//print (breakindex);

	}
	void loadsort(){
		int pathindex=0;

		if(Wavepath.transform.childCount==0){//找到初始
			for(int i=0;i<path.transform.childCount;i++){
				if(path.transform.GetChild(i).GetComponent<floorInfo>().floorSet==9){
					path.transform.GetChild(i).name = "startpath";
					path.transform.GetChild(i).GetComponent<floorInfo>().floorSet=0;
					path.transform.GetChild(i).parent = Wavepath.transform;
					break;
				}
			}
		}
		
		var index = Wavepath.transform.GetChild(Wavepath.transform.childCount-1).gameObject;
		int x_index = index.transform.GetComponent<floorInfo>().x;
		int y_index = index.transform.GetComponent<floorInfo>().y;
		if(x_index==0){
			x_index++;
			if(arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet==2)
				x_index++;
		}
		else if(y_index==0){
			y_index++;
			if(arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet==2)
				y_index++;
		}
		else if(x_index==15){
			x_index--;
			if(arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet==2)
				x_index--;
		}
		else if(y_index==8){
			y_index--;
			if(arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet==2)
				y_index--;
		}
		
		arrObj[x_index,y_index].name = "path"+pathindex;
		pathindex++;
		arrObj[x_index,y_index].transform.parent= Wavepath.transform;
		arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;

		int breakindex=0;
		while(path.transform.childCount>0){
			index = Wavepath.transform.GetChild(Wavepath.transform.childCount-1).gameObject;
			x_index = index.transform.GetComponent<floorInfo>().x;
			y_index = index.transform.GetComponent<floorInfo>().y;

			if(arrObj[x_index+1,y_index].transform.GetComponent<floorInfo>().floorSet==1){//右
				x_index++;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent = Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;
			}
			else if(arrObj[x_index-1,y_index].transform.GetComponent<floorInfo>().floorSet==1){//左
				x_index--;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent = Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;

			}
			else if(arrObj[x_index,y_index+1].transform.GetComponent<floorInfo>().floorSet==1){//上
				y_index++;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent = Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;
			}
			else if(arrObj[x_index,y_index-1].transform.GetComponent<floorInfo>().floorSet==1){//下
				y_index--;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent = Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;
			}
			else if(arrObj[x_index+1,y_index].transform.GetComponent<floorInfo>().floorSet==2&&
					arrObj[x_index+2,y_index].transform.GetComponent<floorInfo>().floorSet==1){//往右走三步
				x_index = x_index+2;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent= Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;

			}
			else if(arrObj[x_index-1,y_index].transform.GetComponent<floorInfo>().floorSet==2&&
					arrObj[x_index-2,y_index].transform.GetComponent<floorInfo>().floorSet==1){//往左走三步
				x_index = x_index-2;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent= Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;

			}
			else if(arrObj[x_index,y_index+1].transform.GetComponent<floorInfo>().floorSet==2&&
					arrObj[x_index,y_index+2].transform.GetComponent<floorInfo>().floorSet==1){//往上走三步
				y_index = y_index+2;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent= Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;
			}
			else if(arrObj[x_index,y_index-1].transform.GetComponent<floorInfo>().floorSet==2&&
				arrObj[x_index,y_index-2].transform.GetComponent<floorInfo>().floorSet==1){//往下走三步
				y_index = y_index-2;
				arrObj[x_index,y_index].name = "path"+pathindex;
				pathindex++;
				arrObj[x_index,y_index].transform.parent= Wavepath.transform;
				arrObj[x_index,y_index].transform.GetComponent<floorInfo>().floorSet=0;

			}
			else{
				for(int i = 0;i<path.transform.childCount;i++){
					if(path.transform.GetChild(i).GetComponent<floorInfo>().floorSet==9){
						path.transform.GetChild(i).name = "endpath";
						path.transform.GetChild(i).parent = Wavepath.transform;
						break;
					}
				}
				break;
			}
			breakindex++;
			if(breakindex>1000){
				print ("break");
				break;
			}
		}
		print (breakindex);


	}
}
