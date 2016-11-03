using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum roleName{
	villager,
	werewolf,
	seer,
	medium,
	bodyguard,
	minion,
	freemason,
	fox,
	cat,
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

	public static Dictionary<string,string> getRoleInfo(roleName role){
		Dictionary<string,string> infoDic = new Dictionary<string,string>();
		switch(role){
			case roleName.villager:
				infoDic.Add("name","村人");
				break;
			case roleName.werewolf:
				infoDic.Add("name","人狼");
				break;
			case roleName.seer:
				infoDic.Add("name","予言者");
				break;
			case roleName.medium:
				infoDic.Add("name","霊媒師");
				break;
			case roleName.bodyguard:
				infoDic.Add("name","狩人");
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
