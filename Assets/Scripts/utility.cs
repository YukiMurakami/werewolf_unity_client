using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum roleName{
	villager,
	werewolf,
	seer,
	medium,
	bodyguard,
	max,
	minion,
	freemason,
	fox,
	cat,

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

	public static Dictionary<string,string> getRoleInfo(roleName role){
		Dictionary<string,string> infoDic = new Dictionary<string,string>();

		switch (role) {
		case roleName.villager:
			infoDic.Add ("name", "村人");
			infoDic.Add ("imageFilename", "card0_k");
			break;
		case roleName.werewolf:
			infoDic.Add ("name", "人狼");
			infoDic.Add ("imageFilename", "card1_k");
			break;
		case roleName.seer:
			infoDic.Add ("name", "予言者");
			infoDic.Add ("imageFilename", "card2_k");
			break;
		case roleName.medium:
			infoDic.Add ("name", "霊媒師");
			infoDic.Add ("imageFilename", "card3_k");
			break;
		case roleName.bodyguard:
			infoDic.Add ("name", "狩人");
			infoDic.Add ("imageFilename", "card4_k");
			break;
		default:
			break;

		}

		return infoDic;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
