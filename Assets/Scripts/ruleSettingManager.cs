using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ruleSettingManager : MonoBehaviour {

	public class RuleData{
		public List<int> roleNum;
		public int afternoonTime;
		public int nightTime;
	}

	public Dropdown afternoonTimeDropdown;
	public Dropdown nightTimeDropdown;

	public void onClick(){
		RuleData ruleData = new RuleData();
		// 配役設定
		ruleData.roleNum = new List<int>();

		for(int i = 0; i < nodeList.Count; i++){
			GameObject obj = nodeList[i].transform.FindChild("roleNum").gameObject;
			string str = obj.GetComponent<Text>().text;
			int num = int.Parse(str);
			ruleData.roleNum.Add(num);
			Debug.Log(num);
		}
		// ruleData.roleNum.Add(2);
		// ruleData.roleNum.Add(1);

		string afternoonTimeText = afternoonTimeDropdown.captionText.text;
		string nightTimeText = nightTimeDropdown.captionText.text;

		// 各種時間設定
		ruleData.afternoonTime = int.Parse(afternoonTimeText);
		ruleData.nightTime = int.Parse(nightTimeText);

		//socketManager.emitRuleEvent(ruleData);
		SceneManager.LoadScene ("room");
	}

	// ruleNode instantiate
	public GameObject roleNodePrefab;
	public GameObject Content;


	public List<GameObject> nodeList;
	public void generateRoleNode(){
		for(int i = 0;i < (int)roleName.max;i++){

			GameObject roleNode = Instantiate (roleNodePrefab) as GameObject;

			string name = utility.getRoleInfo((roleName)i)["name"];
			string imageFilename = "images/" + utility.getRoleInfo ((roleName)i) ["imageFilename"];

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
	
	}
}
