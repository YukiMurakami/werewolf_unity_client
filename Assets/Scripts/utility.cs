using UnityEngine;
using System.Collections;

public class utility : MonoBehaviour {

	public static string createClientId(){
		string c = "abcdefghijklmnopqrstrvwxyz0123456789";
		int cl = c.Length;
		string clientId ="";
		for(int i = 0; i < 16;i++){
			clientId += c.Substring(Random.Range(0,cl-1),1);
		}
		return clientId;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
