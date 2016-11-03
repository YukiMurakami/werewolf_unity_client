using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



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
		ruleData.roleNum.Add(2);
		ruleData.roleNum.Add(1);

		string afternoonTimeText = afternoonTimeDropdown.captionText.text;
		string nightTimeText = nightTimeDropdown.captionText.text;

		// 各種時間設定
		ruleData.afternoonTime = int.Parse(afternoonTimeText);
		ruleData.nightTime = int.Parse(nightTimeText);

		socketManager.emitRuleEvent(ruleData);
	}
	public GameObject roleNode;
	public GameObject Content;
	public GameObject obj;
	public void generateRoleNode(){
		for(int i = 0;i < (int)roleName.max;i++){
			obj = Instantiate(roleNode) as GameObject;
			obj.transform.parent = Content.transform;
			obj.transform.localScale = new Vector3(1, 1, 1);
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
