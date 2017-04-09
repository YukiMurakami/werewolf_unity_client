using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class topManager : MonoBehaviour {

	public Text title;

	public void onClicktoEnterRoom(){
		socketManager.Instance.connect (PlayerPrefs.GetString("ipAddress"), PlayerPrefs.GetString("port"));
	}
	public void onClicktoSetting(){
		SceneManager.LoadScene ("setting");
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//格納されたメッセージを1フレームごとに順番に処理していく
		if (socketManager.Instance.receivedMessages != null) {
			foreach (KeyValuePair<string,JSONObject> pair in socketManager.Instance.receivedMessages) {
				socketManager.Instance.receivedMessages.Remove (pair.Key);
				didReceiveMessage (pair.Key, pair.Value);
				break;
			}
		}
	}

	//アプリ終了時に呼び出されて、ソケットを切断する
	private void OnApplicationQuit (){
		socketManager.Instance.disconnect ();
	}

	//メッセージを受信するとこのメソッドで処理される
	void didReceiveMessage(string key,JSONObject obj) {
		Debug.Log ("received message key:" + key + " mes:" + obj.ToString() + " @topManager");

		if (key == "connectionEstablished") {
			SceneManager.LoadScene ("room");
		}
	}
}
