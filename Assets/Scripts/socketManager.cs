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
				mInstance.receivedMessages = new Dictionary<string,JSONObject> ();

				GameObject go2 = new GameObject("socketIOComponentManager");
				DontDestroyOnLoad (go2);
				mInstance.socket = go2.AddComponent<SocketIOComponent> ();
			}
			return mInstance;
		}
	}

	public Dictionary<string,JSONObject> receivedMessages;
	public SocketIOComponent socket;
	public int id;

	public void connect(string ipaddress,string port) {
		if (!socket.IsConnected) {
			//ws://52.199.129.220:8080/socket.io/?EIO=4&transport=websocket
			string url = "ws://" + ipaddress + ":" + port + "/socket.io/?EIO=4&transport=websocket";
			PlayerPrefs.SetString ("urlForSocketIO",url);
			socket.autoConnect = true;
			socket.Connect ();

			Debug.Log ("attempt to connect:" + ipaddress + ":" + port);

			socket.On ("memberChanged", ((SocketIOEvent e) => {
				receivedMessages.Add ("memberChanged",e.data);
			}));
			socket.On ("connectionEstablished", ((SocketIOEvent e) => {
				receivedMessages.Add ("connectionEstablished", e.data);
			}));
			socket.On ("roleAck", ((SocketIOEvent e) => {
				receivedMessages.Add ("roleAck", e.data);
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
		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		foreach (KeyValuePair<string,string> pair in data) {
			jsonObject.AddField(pair.Key, pair.Value);
		}
		EmitData (jsonObject, eventName);
	}

	public void EmitData(JSONObject json,string eventName) {
		Debug.Log ("emit " + eventName + json.ToString());
		socket.Emit(eventName, json);
	}

	// Update is called once per frame
	void Update () {
	}
}
