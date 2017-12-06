using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadmap : MonoBehaviour {
	public GameObject [] MapObj=new GameObject[5];
	GameObject Wavepath,path,startpath;

	// Use this for initialization
	void Start () {
		var str = PlayerPrefs.GetString("mapinfo");
		//print (str.Length);
		int len=0;
		var loadmap = new GameObject();
		path = new GameObject();
		Wavepath = new GameObject();
		loadmap.name = "loadmap";
		path.name = "path";
		Wavepath.name = "Wavapath";
		loadmap.transform.parent = gameObject.transform;
		path.transform.parent= gameObject.transform;
		Wavepath.transform.parent= gameObject.transform;

		for(var i=0;i<16;i++)
			for(int j=0;j<9;j++){
				var a = str.Substring(i*9+j,1);
				var setGround = new Vector3(-7.5f+i, -4f+j, 0);				
				if(a.Equals("1")){
					GameObject newfloor =  Instantiate(MapObj[0], setGround, transform.rotation);
                	newfloor.transform.parent = path.transform;
                	newfloor.AddComponent<makePath>();
                	newfloor.AddComponent<BoxCollider2D>();
               		var setpos =newfloor.GetComponent<makePath>();
                	setpos.x=i;setpos.y=j;
					newfloor.GetComponent<SpriteRenderer>().color = Color.red;
				}
				else if(a.Equals("9")){
					startpath =  Instantiate(MapObj[0], setGround, transform.rotation);
					startpath.name = "startpath";
                	startpath.transform.parent = Wavepath.transform;
                	startpath.AddComponent<makePath>();
                	startpath.AddComponent<BoxCollider2D>();
               		var setpos =startpath.GetComponent<makePath>();
                	setpos.x=i;setpos.y=j;
					startpath.GetComponent<SpriteRenderer>().color = Color.red;

				}
				else{
					GameObject newfloor =  Instantiate(MapObj[0], setGround, transform.rotation);
                	newfloor.transform.parent = loadmap.transform;
                	newfloor.AddComponent<makePath>();
                	newfloor.AddComponent<BoxCollider2D>();
                	var setpos =newfloor.GetComponent<makePath>();
                	setpos.x=i;setpos.y=j;
				}
					
			
		//loadmap.transform.localScale= new Vector3(0.8f,0.8f,0);
		}
		//print (startpath);
		Pathsort();

	}
	
	// Update is called once per frame
	public void Pathsort(){
		var index =0;
		var breakindex=0;
		var standard = startpath;
		while (path.transform.childCount>0){
			var obj = path.transform.GetChild(index).gameObject;
			var posxy = obj.GetComponent<makePath>();
			var standardxy = standard.GetComponent<makePath>();
			int m = Mathf.Abs(standardxy.x-posxy.x);
			int n = Mathf.Abs(standardxy.y-posxy.y);
			if(m==1&&n==0){//posxy 為下個路徑左右
				obj.transform.parent = Wavepath.transform;
				standard = obj;
			}
			if(m==0&&n==1){//posxy 為下個路徑上下
				obj.transform.parent = Wavepath.transform;
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
}
