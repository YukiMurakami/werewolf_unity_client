using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roleCheckManager : MonoBehaviour {

	public void onClicktoChat(){ //チャットシーンへ
		SceneManager.LoadScene ("chat");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
