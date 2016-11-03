#pragma strict
import UnityEngine.UI;
var nameField : InputField;
var roomIdField : InputField;
var ipAddressField : InputField;
var portField : InputField;
var clientIdText : Text;


function onClick(){
	Debug.Log("clicked!");
	// serve field
	PlayerPrefs.SetString("name",nameField.text);
	PlayerPrefs.SetString("roomId",roomIdField.text);
	PlayerPrefs.SetString("ipAddress",ipAddressField.text);
	PlayerPrefs.SetString("port",portField.text);
}

function Start () {
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

function Update () {

}