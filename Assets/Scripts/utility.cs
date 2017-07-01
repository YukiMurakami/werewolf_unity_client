using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Role{
	villager,
	werewolf,
	seer,
	medium,
	bodyguard,
	madman,
	max,
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

	public static Dictionary<string,string> getRoleInfo(Role role){
		Dictionary<string,string> infoDic = new Dictionary<string,string>();

		switch (role) {
		case Role.villager:
			infoDic.Add ("namejp", "村人");
			infoDic.Add ("nameeng", "Villager");
			infoDic.Add ("token","村");
			infoDic.Add ("imageFilename", "card0_k");
			infoDic.Add ("roleExplainText","あなたは「村人」です。村人は特殊な能力を持たないただの人です。夜時間は考察を書きましょう。");
			infoDic.Add ("firstNightMessage","あなたは「村人」です。夜時間は必ず考察を書き込んでください。誰が人狼か、誰が真の役職なのかなど推理してください。");
			break;
		case Role.werewolf:
			infoDic.Add ("namejp", "人狼");
			infoDic.Add ("nameeng", "Werewolf");
			infoDic.Add ("token","狼");
			infoDic.Add ("imageFilename", "card1_k");
			infoDic.Add ("roleExplainText","あなたは「人狼」です。人狼は毎晩仲間同士で相談し人間を一人噛むことができます。夜時間は狼専用チャットで相談し、代表者が襲撃先を選択します。");
			infoDic.Add ("firstNightMessage","ここは「人狼専用チャット」です。仲間と相談できます。なお、夜時間終了までに代表者がアクションボタンから、襲撃先を決定してください。アクションが行われなかった場合はランダムに1名決定します。");
			break;
		case Role.seer:
			infoDic.Add ("namejp", "予言者");
			infoDic.Add ("nameeng", "Seer");
			infoDic.Add ("token","占");
			infoDic.Add ("imageFilename", "card2_k");
			infoDic.Add ("roleExplainText","あなたは「予言者」です。予言者は毎晩疑っている人物を１人指定してその人物が人狼かそうでないかを知ることができます。");
			infoDic.Add ("firstNightMessage","あなたは「予言者」です。考察を書き込みつつ、夜時間中に占い作業を完了してください。");
			break;
		case Role.medium:
			infoDic.Add ("namejp", "霊媒師");
			infoDic.Add ("nameeng", "Medium");
			infoDic.Add ("token","霊");
			infoDic.Add ("imageFilename", "card3_k");
			infoDic.Add ("roleExplainText","あなたは「霊媒師」です。霊媒師は毎晩その日の昼のターンに処刑された人が人狼だったのかそうでなかったのかを知ることができます。");
			infoDic.Add ("firstNightMessage","あなたは「霊媒師」です。昼に処刑された人の正体が表示されます。");
			break;
		case Role.bodyguard:
			infoDic.Add ("namejp", "狩人");
			infoDic.Add ("nameeng", "Guard");
			infoDic.Add ("token","狩");
			infoDic.Add ("imageFilename", "card4_k");
			infoDic.Add ("roleExplainText","あなたは「狩人」です。狩人は毎晩誰かを一人指定してその人物を人狼の襲撃から守ります。ただし、自分自身を守ることはできません。");
			infoDic.Add ("firstNightMessage","あなたは「狩人」です。よる時間中に護衛先を選択してください。選択しなかった場合はランダムで護衛します。");
			break;
		case Role.madman:
			infoDic.Add ("namejp", "狂人");
			infoDic.Add ("nameeng", "Madman");
			infoDic.Add ("token","狂");
			infoDic.Add ("imageFilename", "card5_k");
			infoDic.Add ("roleExplainText","あなたは「狂人」です。狂人は何も能力を持っていませんが、人狼が勝つと勝利します。");
			infoDic.Add ("firstNightMessage","あなたは「狂人」です。能力はありませんが嘘をついて村を混乱させましょう。");
			break;
		default:
			// infoDic.Add ("namejp", "役職名");
			// infoDic.Add ("nameeng", "roleName");
			// infoDic.Add ("token","村");
			// infoDic.Add ("imageFilename", "card000_k");
			// infoDic.Add ("roleExplainText","あなたは「役職名」です。説明文");
			// infoDic.Add ("firstNightMessage","説明文");
			break;

		}

		return infoDic;
	}

	public static Role getRoleFromEnglish(string roleNameEng) {
		for (Role role = 0; role < Role.max; role++) {
			if (getRoleInfo (role) ["nameeng"] == roleNameEng) {
				return role;
			}
		}
		return Role.max;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
