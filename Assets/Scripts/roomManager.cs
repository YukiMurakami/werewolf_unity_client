using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class roomManager : MonoBehaviour {

	public void onClicktoSetting(){ // 設定画面へ
		SceneManager.LoadScene ("ruleSetting");
	}
	public void onClickStart(){ // ゲーム開始画面:startGame
	}
	public void onClicktoExit(){// ゲーム退出:exitRoom
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
