using UnityEngine;
using SocketIO;

public class TestSocketIO : MonoBehaviour
{
	SocketIOComponent socket;

	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("online", OnOnline);
		socket.On("offline", OnOffline);

		socket.On("message", OnMessage);
	}

	public void OnOnline(SocketIOEvent e)
	{
		string id = e.data.GetField("id").str;

		Debug.Log("online id: " + id);
	}

	public void OnOffline(SocketIOEvent e)
	{
		string id = e.data.GetField("id").str;

		Debug.Log("offline id: " + id);
	}

	public void OnMessage(SocketIOEvent e)
	{
		JSONObject obj = e.data;

		string id = obj.GetField("id").str;
		string message = obj.GetField("message").str;

		Debug.Log("message id: " + id + " message: " + message);
	}

	public void EmitMessage(string message)
	{
		JSONObject jsonObject = new JSONObject(JSONObject.Type.OBJECT);
		jsonObject.AddField("message", message);

		socket.Emit("message", jsonObject);
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			EmitMessage ("hello world");
			Debug.Log ("click");
		}
	}
}