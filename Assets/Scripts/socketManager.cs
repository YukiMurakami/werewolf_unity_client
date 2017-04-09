using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using SocketIO;

public class EmitListFormat {
	public string name;
	public List<string> args;
}

public class EmitListListFormat {
	public string name;
	public List<List<string>> args;
}

public class EmitDictionaryFormat {
	public string name;
	public List<Dictionary<string,string > > args;
}

public class socketManager : MonoBehaviour {

	private static socketManager mInstance;

	public static socketManager Instance {
		get {
			if (mInstance == null) {
				GameObject go = new GameObject ("socketManager");
				DontDestroyOnLoad (go);
				mInstance = go.AddComponent<socketManager> ();
				mInstance.id = Random.Range (0, 1000000);
				mInstance.receivedMessages = new Dictionary<string,List<string>> ();
			}
			return mInstance;
		}
	}

	public Dictionary<string,List<string>> receivedMessages;
	public SocketIOComponent socket;
	public int id;




	public void connect(string ipaddress,string port) {
		if (socket == null) {
			//ws://52.199.129.220:8080/socket.io/?EIO=4&transport=websocket
			string url = "ws://" + ipaddress + ":" + port + "/socket.io/?EIO=4&transport=websocket";
			PlayerPrefs.SetString ("urlForSocketIO",url);

			GameObject prefab = Resources.Load ("Prefabs/SocketIO") as GameObject;
			GameObject go = Instantiate (prefab);
			go.transform.parent = GameObject.Find ("socketManager").transform;
			socket = go.GetComponent<SocketIOComponent> ();
			Debug.Log ("attempt to connect:" + ipaddress + ":" + port);

			socket.On ("memberChanged", ((SocketIOEvent e) => {
				Debug.Log("aaaaa");
			}));

			socket.On ("connectionEstablished", ((SocketIOEvent e) => {
				receivedMessages.Add ("connectionEstablished", new List<string>{ "" });
			}));
		}
	}

	public void disconnect() {
		if (socket != null) {
			socket.Close ();
		}
	}

	// Use this for initialization
	void Start () {
	}

	public void EmitDictionaryData(Dictionary<string,string> data,string eventName)
	{
		Debug.Log ("emit " + eventName);
		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		foreach (KeyValuePair<string,string> pair in data) {
			jsonObject.AddField(pair.Key, pair.Value);
		}

		socket.Emit(eventName, jsonObject);
	}

	// Update is called once per frame
	void Update () {
	}
}
