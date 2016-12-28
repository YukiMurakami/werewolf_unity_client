using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class roomManager : MonoBehaviour {

	public GameObject memberNodePrefab;
	public GameObject Content;

	//ソケットで受信したメッセージが格納される
	public static Dictionary<string,List<string>> receivedMessages;



	public void onClicktoSetting(){ // 設定画面へ
		SceneManager.LoadScene ("ruleSetting");
	}
	public void onClickStart(){ // ゲーム開始画面:startGame
	}
	public void onClicktoExit(){// ゲーム退出:exitRoom
	}
		// memberNode instantiate


	public List<GameObject> nodeList;
	public void generateMemberNode(){
		for(int i = 0;i < 13;i++){

			GameObject memberNode = Instantiate (memberNodePrefab) as GameObject;

			string name = "test" + i;

			memberNode.transform.FindChild("memberText").gameObject.GetComponent<Text>().text = name;
			memberNode.transform.SetParent (Content.transform);
			memberNode.transform.localScale = new Vector3(1,1, 1);

			nodeList.Add(memberNode);
		}
	}



	// Use this for initialization
	void Start () {
		generateMemberNode();
	}
	
	// Update is called once per frame
	void Update () {
		//格納されたメッセージを1フレームごとに順番に処理していく
		foreach (KeyValuePair<string,List<string>> pair in receivedMessages) {
			didReceiveMessage (pair.Key, pair.Value);
			receivedMessages.Remove (pair.Key);
			break;
		}
	}

	//アプリ終了時に呼び出されて、ソケットを切断する（すべてのシーンで必要）
	private void OnApplicationQuit (){
		socketManager.Instance.disconnect ();
	}

	//メッセージを受信するとこのメソッドで処理される
	void didReceiveMessage(string key,List<string> messages) {
		string[] messageArray = messages.ToArray ();
		Debug.Log ("key:" + key + " mes:" + string.Join(",",messageArray) + " @opening");

		if (key == "hogehoge") {

		}
	}
}
