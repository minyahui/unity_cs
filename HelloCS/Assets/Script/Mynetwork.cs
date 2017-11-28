using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mynetwork : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
	public int connections = 10;
	public int listenPort = 8899;
	public bool useBat = false;
	public string ip = "127.0.0.1";
	public GameObject playerPrefab;
	void OnGUI(){
		if (Network.peerType == NetworkPeerType.Disconnected) {
			if (GUILayout.Button ("创建服务器")) {
				NetworkConnectionError error = Network.InitializeServer (connections, listenPort, useBat);
				print (error);
			} else if (GUILayout.Button ("连接服务器")) {
				NetworkConnectionError error = Network.Connect (ip, listenPort);
				print (error);
			}
		} else if (Network.peerType == NetworkPeerType.Server) {
			GUILayout.Label("服务器创建完成");
		} else if (Network.peerType == NetworkPeerType.Client) {
			GUILayout.Label("客户端已经接入");
		}
	}
	// 这两个方法都是在服务器端调用的
	void OnServerInitialized(){
		print ("Server完成初始化");
		//Network.player;//可以直接访问到当前的Player，客户端
		int group = int.Parse(Network.player + "");// 直接访问Network.player会得到当前客户端的索引，这个是唯一的
		Network.Instantiate (playerPrefab,new Vector3(0,10,0),Quaternion.identity,group);
	}
	void OnPlayerConnected(NetworkPlayer player){
		print ("一个客户端连接过来， Index Number" + player);
	}
	// 
	void OnConnectedToServer(){
		print ("成功连接到了服务器");
		int group = int.Parse(Network.player + "");// 直接访问Network.player会得到当前客户端的索引，这个是唯一的
		Network.Instantiate (playerPrefab,new Vector3(0,10,0),Quaternion.identity,group);
	}
	// network view 组件用来在局域网之内去同步一个物体游戏物体的组件
	// network view 会把创建出来它的客户端作为主人
}
