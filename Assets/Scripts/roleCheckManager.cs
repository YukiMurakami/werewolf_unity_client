using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roleCheckManager : MonoBehaviour {

	public Image roleImage;
	public Text roleExplainText;

	public void onClicktoChat(){ //チャットシーンへ
		//SceneManager.LoadScene ("chat");
	}
	// Use this for initialization
	void Start () {
		Role role = (Role)PlayerPrefs.GetInt ("role");
		Debug.Log (role);
		string imageFilename = "images/" + utility.getRoleInfo (role) ["imageFilename"];
		roleImage.sprite = Resources.Load<Sprite> (imageFilename);
		//roleExplainText.text = utility.getRoleInfo(role)[""]
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
