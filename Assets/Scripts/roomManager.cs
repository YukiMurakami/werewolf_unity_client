using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using SocketIO;
using System;


public class roomManager : MonoBehaviour {

	public GameObject memberNodePrefab;
	public GameObject Content;
	public List<GameObject> nodeList;
	List<string> playerNames;

	public void onClicktoSetting(){ // 設定画面へ
		SceneManager.LoadScene ("ruleSetting");
	}
	public void onClickStart(){ // ゲーム開始画面:startGame
	}
	public void onClicktoExit(){// ゲーム退出:exitRoom
	}

	public void generateMemberNode(){
		for (int i = 0; i < nodeList.Count; i++) {
			Destroy (nodeList [i]);
		}
		nodeList.Clear ();
		for(int i = 0;i < playerNames.Count;i++){
			GameObject memberNode = Instantiate (memberNodePrefab) as GameObject;
			memberNode.transform.FindChild("memberText").gameObject.GetComponent<Text>().text = playerNames [i];
			memberNode.transform.SetParent (Content.transform);
			memberNode.transform.localScale = new Vector3(1,1, 1);

			nodeList.Add(memberNode);
		}
	}

	// Use this for initialization
	void Start () {
		playerNames = new List<string> ();
		nodeList = new List<GameObject> ();
		generateMemberNode();

		//send joinRoom
		socketManager.Instance.EmitDictionaryData (new Dictionary<string,string> () {
			{ "userId",PlayerPrefs.GetString ("clientId") },
			{ "name",PlayerPrefs.GetString ("name") },
		}, "joinRoom");
	}
	
	// Update is called once per frame
	void Update () {
		//格納されたメッセージを1フレームごとに順番に処理していく
		foreach (KeyValuePair<string,JSONObject> pair in socketManager.Instance.receivedMessages) {
			socketManager.Instance.receivedMessages.Remove (pair.Key);
			didReceiveMessage (pair.Key, pair.Value);
			break;
		}
	}

	//アプリ終了時に呼び出されて、ソケットを切断する（すべてのシーンで必要）
	void OnApplicationQuit (){
		socketManager.Instance.disconnect ();
	}

	//メッセージを受信するとこのメソッドで処理される
	void didReceiveMessage(string key,JSONObject obj) {
		Debug.Log ("received message key:" + key + " mes:" + obj.ToString() + " @roomManager");

		if (key == "memberChanged") {
			playerNames.Clear ();
			for (int i = 0; i < obj.list.Count; i++) {
				Dictionary<string,string> dic = obj.list [i].ToDictionary ();
				playerNames.Add (dic["name"]);
			}
			generateMemberNode ();
		}
	}
}
