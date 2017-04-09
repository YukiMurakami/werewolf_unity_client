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
			infoDic.Add ("namejp", "村人");
			infoDic.Add ("nameeng", "Villager");
			infoDic.Add ("imageFilename", "card0_k");
			break;
		case roleName.werewolf:
			infoDic.Add ("namejp", "人狼");
			infoDic.Add ("nameeng", "Werewolf");
			infoDic.Add ("imageFilename", "card1_k");
			break;
		case roleName.seer:
			infoDic.Add ("namejp", "予言者");
			infoDic.Add ("nameeng", "Seer");
			infoDic.Add ("imageFilename", "card2_k");
			break;
		case roleName.medium:
			infoDic.Add ("namejp", "霊媒師");
			infoDic.Add ("nameeng", "Medium");
			infoDic.Add ("imageFilename", "card3_k");
			break;
		case roleName.bodyguard:
			infoDic.Add ("namejp", "狩人");
			infoDic.Add ("nameeng", "Guard");
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
