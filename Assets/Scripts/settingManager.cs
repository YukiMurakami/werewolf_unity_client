using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class settingManager : MonoBehaviour {

	public InputField nameField;
	public InputField roomIdField;
	public InputField ipAddressField;
	public InputField portField;
	public Text clientIdText;

	public void onClick(){
		PlayerPrefs.SetString("name",nameField.text);
		PlayerPrefs.SetString("roomId",roomIdField.text);
		PlayerPrefs.SetString("ipAddress",ipAddressField.text);
		PlayerPrefs.SetString("port",portField.text);
	}

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
