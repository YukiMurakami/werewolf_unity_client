using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIOClient;
using LitJson;
using UnityEngine.SceneManagement;

public class EmitListFormat {
	public string name;
	public List<string> args;
}

public class EmitDictionaryFormat {
	public string name;
	public List<Dictionary<string,string > > args;
}

public class SampleSocketIO : MonoBehaviour {

	public static SocketIOClient.Client socket;

	public static void connect(string ipaddress,string port) {
		/*
		Debug.Log("attempt to connect:" + ipaddress + ":" + port);
		socket = new SocketIOClient.Client("http://" + ipaddress + ":" + port);
		Opening.sendDebugLog ("attempt to connect:" + ipaddress + ":" + port);

		socket.On("connect-result",(data) => {
			Debug.Log("json:" + data.MessageText);
			Opening.sendDebugLog("json:" + data.MessageText);
			EmitListFormat format = JsonMapper.ToObject<EmitListFormat>(data.MessageText);
			if(format.args[0] == "success") {
				Opening.didConnect(true);
			} else {
				Opening.didConnect(false);
			}
		});

		socket.On ("game-start", (data) => {
			Debug.Log("json:" + data.MessageText);
			Opening.sendDebugLog("json:" + data.MessageText);
			EmitDictionaryFormat format = JsonMapper.ToObject<EmitDictionaryFormat>(data.MessageText);
			Main.nowPlayerId = int.Parse(format.args[0]["firstPlayer"]);
			string [] array = format.args[0]["players"].Split(',');
			List<string> players = new List<string>(array);
			Main.playerId = players.IndexOf(Opening.name);

			Opening.didEnteredRoom();
		});

		socket.On ("update-squares", (data) => {
			Debug.Log("json:" + data.MessageText);
			Opening.sendDebugLog("json:" + data.MessageText);
			EmitDictionaryFormat format = JsonMapper.ToObject<EmitDictionaryFormat>(data.MessageText);

			Main.nowPlayerId = int.Parse(format.args[0]["nextPlayer"]);

			Main.setSquares(format.args[0]["squares"]);
		});
		*/
		socket.Connect();
		//Opening.sendDebugLog ("socket connect done");
	}

	public static void emit(string eventName,string message) {
		socket.Emit (eventName, message);
	}


	/*
	void OnGUI() {
		if (GUILayout.Button ("Connect")) {
			Debug.Log ("clicked Connect Button");
			client = new SocketIOClient.Client ("http://127.0.0.1:8080");
			client.On ("mes", (data) => {
				Debug.Log(data.Json.ToJsonString());
			});
			client.Connect ();
		}

		if (GUILayout.Button ("Send message")) {
			client.Emit("msg","hahahaha");
		}
		if (GUILayout.Button("Send Login info")) {
			// LitJsonを使いJSONデータを生成
			JsonData data = new JsonData();
			data["name"] = "haruki";
			data ["roomId"] = 100;
			// シリアライズする(LitJson.JsonData→JSONテキスト)
			string postJsonStr = data.ToJson();
			client.Emit("EnterRoom",postJsonStr);
		}
		if (GUILayout.Button("Close")) {
			client.Close();
		}
	}
	*/
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
