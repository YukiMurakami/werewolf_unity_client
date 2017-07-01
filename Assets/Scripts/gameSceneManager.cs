using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSceneManager : MonoBehaviour {
	public Text timeText;
	public Text phaseText;
	public Text resultText;
	
	public enum Scene{
		morning,
		afternoon,
		evening,
		excution,
		night,
		dead,
		heaven,
		result,
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
