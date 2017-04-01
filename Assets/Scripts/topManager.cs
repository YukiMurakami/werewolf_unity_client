using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class topManager : MonoBehaviour {

	public Text title;

	//ソケットで受信したメッセージが格納される
	public static Dictionary<string,List<string>> receivedMessages;

	public void onClicktoEnterRoom(){
		socketManager.Instance.connect (PlayerPrefs.GetString("ipAddress"), PlayerPrefs.GetString("port"));
	}
	public void onClicktoSetting(){
		SceneManager.LoadScene ("setting");
	}


	void Awake() {
		receivedMessages = new Dictionary<string,List<string>> ();
	}
	// Use this for initialization
	void Start () {

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
		Debug.Log ("received message key:" + key + " mes:" + string.Join(",",messageArray) + " @topManager");

		if (key == "connectionEstablished") {
			//success connection
			SceneManager.LoadScene ("room");
		}
	}
}
