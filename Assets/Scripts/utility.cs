using UnityEngine;
using System.Collections;

public enum roleName{
	villager,
	werewolf,
	seer,
	medium,
	bodyguard,
	max
}

public class utility : MonoBehaviour {

	public static string createClientId(){
		string c = "abcdefghijklmnopqrstrvwxyz0123456789";
		int cl = c.Length;
		string clientId ="";
		for(int i = 0; i < 16;i++){
			clientId += c.Substring(Random.Range(0,cl-1),1);
		}
		return clientId;
	}

	// public static Dictionary<string,string> getRoleInfo(roleName){
	// 	Dictionary<string,string> infoDic = new Dictionary<string,string>();
	// 	switch(roleName){
	// 		case roleName.villager:
	// 			infoDic.Add("name","村人");
	// 			break;

	// 		case roleName.werewolf:
	// 			infoDic.Add("name","人狼");
	// 			break;

	// 	}
	// }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
