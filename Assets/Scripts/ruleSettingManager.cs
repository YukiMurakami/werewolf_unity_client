using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ruleSettingManager : MonoBehaviour {

	public Dropdown afternoonTimeDropdown;
	public Dropdown nightTimeDropdown;
	// ruleNode instantiate
	public GameObject roleNodePrefab;
	public GameObject Content;
	public List<GameObject> nodeList;


	public void onClick(){
		// 配役設定
		Dictionary<string,string> roleSet = new Dictionary<string,string> ();

		for(int i = 0; i < nodeList.Count; i++){
			GameObject obj = nodeList[i].transform.FindChild("roleNum").gameObject;
			string str = obj.GetComponent<Text>().text;
			roleSet.Add (utility.getRoleInfo ((Role)i) ["nameeng"], str);
			//Debug.Log(num);
		}

		JSONObject roleSetObj = new JSONObject (roleSet);

		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField ("dayTime", int.Parse (afternoonTimeDropdown.captionText.text) * 60);
		jsonObject.AddField ("nightTime", int.Parse (nightTimeDropdown.captionText.text) * 60);
		jsonObject.AddField ("nightTimeDecreasesBy", 60);
		jsonObject.AddField ("firstNightSee", "choice");
		jsonObject.AddField ("roleLackable", false);
		jsonObject.AddField ("roleSet", roleSetObj);


		socketManager.Instance.EmitData (jsonObject, "changeRule");
		SceneManager.LoadScene ("room");
	}


	public void generateRoleNode(){
		for(int i = 0;i < (int)Role.max;i++){

			GameObject roleNode = Instantiate (roleNodePrefab) as GameObject;

			string name = utility.getRoleInfo((Role)i)["namejp"];
			string imageFilename = "images/" + utility.getRoleInfo ((Role)i) ["imageFilename"];

			roleNode.GetComponent<RoleNumCounter> ().roleNameText.text = name;
			Sprite sprite = Resources.Load<Sprite> (imageFilename);
			roleNode.GetComponent<RoleNumCounter> ().roleImage.sprite = sprite;
			roleNode.transform.SetParent (Content.transform);
			roleNode.transform.localScale = new Vector3(1.8f, 1.8f, 1);

			nodeList.Add(roleNode);
		}
	}

	// Use this for initialization
	void Start () {
		generateRoleNode();
	}
	
	// Update is called once per frame
	void Update () {
		//格納されたメッセージを1フレームごとに順番に処理していく
		foreach (KeyValuePair<string,JSONObject> pair in socketManager.Instance.receivedMessages) {
			socketManager.Instance.receivedMessages.Remove (pair.Key);
			didReceiveMessage (pair.Key, pair.Value);
			break;
		}
	}

	//アプリ終了時に呼び出されて、ソケットを切断する（すべてのシーンで必要）
	void OnApplicationQuit (){
		socketManager.Instance.disconnect ();
	}

	//メッセージを受信するとこのメソッドで処理される
	void didReceiveMessage(string key,JSONObject obj) {
		Debug.Log ("received message key:" + key + " mes:" + obj.ToString() + " @Manager");


	}
}
