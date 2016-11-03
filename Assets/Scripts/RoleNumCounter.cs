using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoleNumCounter : MonoBehaviour {

	public Text roleNum;

	public void onClickPlus(){
		Debug.Log(roleNum.text);
		int num = int.Parse(roleNum.text);
		num++;
		roleNum.text = num.ToString();
	}
	public void onClickMinus(){
		Debug.Log(roleNum.text);
		int num = int.Parse(roleNum.text);
		if(num != 0){
			num--;		
		}
		roleNum.text = num.ToString();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
