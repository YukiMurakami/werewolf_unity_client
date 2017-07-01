using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameSceneManager : MonoBehaviour {
	public Text timeText;
	public Text phaseText;
	public Text resultText;

	public enum Scene{
		morning,
		afternoon,
		evening,
		excution,
		night,
		dead,
		heaven,
		result,
	}
	public void onClicktoAfternoon(){
		// SceneManager.LoadScene ("room");
	}
	public void onClicktoEvening(){
		// SceneManager.LoadScene ("room");
	}
	public void onClicktoNight(){
		// SceneManager.LoadScene ("room");
	}
	public void onClicktoVotingHistory(){

	}
	public void onClicktoVictimHistory(){

	}

	// Use this for initialization
	void Start () {
		// dayを取得する
		int day = 3;
		resultText.text = System.String.Format("{0}日目の朝になりました。昨晩の犠牲者はplayerDでした。（昨晩のアクション：playerBがplayerDをかみました）",day);
		phaseText.text = day + "日目朝";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
