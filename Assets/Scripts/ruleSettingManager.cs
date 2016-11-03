using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleData{
	public List<int> roleNum;
	public int afternoonTime;
	public int nightTime;
}

public class ruleSettingManager : MonoBehaviour {
	public void onClick(){
		RuleData ruleData = new RuleData();
		ruleData.roleNum = new List<int>();
		ruleData.role.Add(2);
		ruleData.role.Add(1);
		ruleData.afternoonTime = 5;
		ruleData.nightTime = 3;

		emitRuleEvent(ruleData);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
