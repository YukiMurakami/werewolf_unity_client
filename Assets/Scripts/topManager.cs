﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class topManager : MonoBehaviour {


	public void onClicktoEnterRoom(){
		SceneManager.LoadScene ("room");
	}
	public void onClicktoSetting(){
		SceneManager.LoadScene ("setting");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
