using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public UIInput ipInput;
	public GameObject uiRoot;
	public GameObject soliderPrefabs;
	public int connections = 100;//最大连接数
	public int listenPort = 8989;//监听端口
	public Transform pos1;
	public Transform pos2;
	public bool useBat = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// 当创建服务器按钮被按下的时候执行
	public void OnButtonCreateServerClick(){
		Network.InitializeServer (connections, listenPort, useBat);
		uiRoot.SetActive (false);
	}
	// 当连接服务器按钮被按下的时候执行
	public void OnButtonConnectServerClick(){
		print ("开始连接服务器" + ipInput.value);
		Network.Connect ("127.0.0.1", listenPort);
		uiRoot.SetActive (false);
	}
	// 这两个方法都是在服务器端调用的
	void OnServerInitialized(){
		print ("Server完成初始化");
		int group = int.Parse(Network.player + "");// 直接访问Network.player会得到当前客户端的索引，这个是唯一的
		Network.Instantiate (soliderPrefabs, pos1.position, Quaternion.identity,group);
		Cursor.visible = false;
	}
	// 
	void OnConnectedToServer(){
		print ("成功连接到了服务器");
		int group = int.Parse(Network.player + "");// 直接访问Network.player会得到当前客户端的索引，这个是唯一的
		Network.Instantiate (soliderPrefabs, pos2.position, Quaternion.identity,group);
		Cursor.visible = false;
	}
	// network view 组件用来在局域网之内去同步一个物体游戏物体的组件
	// network view 会把创建出来它的客户端作为主人
}
