using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class topManager : MonoBehaviour {

	public static Dictionary<string,List<string>> receivedMessages;

	public void onClicktoEnterRoom(){
		//SceneManager.LoadScene ("room");
		socketManager.Instance.connect (PlayerPrefs.GetString("ipAddress"), PlayerPrefs.GetString("port"));
	}
	public void onClicktoSetting(){
		SceneManager.LoadScene ("setting");
	}
	// Use this for initialization
	void Start () {
		receivedMessages = new Dictionary<string,List<string>> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (KeyValuePair<string,List<string>> pair in receivedMessages) {
			didReceiveMessage (pair.Key, pair.Value);
			receivedMessages.Remove (pair.Key);
			break;
		}
	}

	private void OnApplicationQuit (){
		socketManager.Instance.disconnect ();
	}

	void didReceiveMessage(string key,List<string> messages) {
		string[] messageArray = messages.ToArray ();
		Debug.Log ("key:" + key + " mes:" + string.Join(",",messageArray) + " @opening");

		if (key == "map") {
			PlayerPrefs.SetString ("mapString", messages [0]);

			if (PlayerPrefs.HasKey ("mapString") && PlayerPrefs.HasKey ("robotString")) {
				SceneManager.LoadScene ("main");
			}
		}

	}
}
