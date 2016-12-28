using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingManager : MonoBehaviour {

	public InputField nameField;
	public InputField roomIdField;
	public InputField ipAddressField;
	public InputField portField;
	public Text clientIdText;

	static bool isFinishConnect;

	public void onClick(){

		// 保存
		PlayerPrefs.SetString("name",nameField.text);
		PlayerPrefs.SetString("roomId",roomIdField.text);
		PlayerPrefs.SetString("ipAddress",ipAddressField.text);
		PlayerPrefs.SetString("port",portField.text);

		//Dictionaryを作る
		 Dictionary<string,string> userInfo = new Dictionary<string,string>();
		 userInfo.Add("name",nameField.text);
		 userInfo.Add("clientId",clientIdText.text);
		 userInfo.Add("roomId",roomIdField.text);

		SceneManager.LoadScene ("top");
	}

	// Use this for initialization
	void Start () {
		isFinishConnect = false;
		// getField
		if(PlayerPrefs.HasKey("name")){
			nameField.text = PlayerPrefs.GetString("name");
		}

		if(PlayerPrefs.HasKey("roomId")){
			roomIdField.text = PlayerPrefs.GetString("roomId");
		}

		if(PlayerPrefs.HasKey("ipAddress")){
			ipAddressField.text = PlayerPrefs.GetString("ipAddress");
		}

		if(PlayerPrefs.HasKey("port")){
			portField.text = PlayerPrefs.GetString("port");
		}

		if(PlayerPrefs.HasKey("clientId")){
			clientIdText.text = PlayerPrefs.GetString("clientId");
		}else{
			clientIdText.text = utility.createClientId();// 初回起動時にclientIdをcreate
			PlayerPrefs.SetString("clientId",clientIdText.text);
		}
	}

	public static void didConnect() {
		isFinishConnect = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFinishConnect) {
			SceneManager.LoadScene ("ruleSetting");
		}
	}
}
