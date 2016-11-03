using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RuleData{
	public List<int> roleNum;
	public int afternoonTime;
	public int nightTime;
}

public class ruleSettingManager : MonoBehaviour {
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

		// emitRuleEvent(ruleData);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
