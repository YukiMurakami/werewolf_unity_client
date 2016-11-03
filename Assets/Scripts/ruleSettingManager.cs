using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RuleData{
	public List<int> role;
	public int afternoonTime;
	public int nightTime;
}

public class ruleSettingManager : MonoBehaviour {
	public void onClick(){
		RuleData ruleData = new RuleData();
		ruleData.role = new List<int>();
		ruleData.role.Add(5);

		ruleData.afternoonTime = 5;
		ruleData.nightTime = 3;

		// joinRoomEvent(ruleData);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
