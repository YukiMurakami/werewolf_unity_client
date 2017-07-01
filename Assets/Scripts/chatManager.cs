using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class chatManager : MonoBehaviour {

	public InputField messageInputField;
	public GameObject scrollViewContent;
	public GameObject scrollView;
	public GameObject chatCellNodePrefab;


	List<GameObject> cells;

	void addMessage(string name,string mes,chatCellNodeManager.BalloonDirection direction) {
		GameObject chatCellNode = Instantiate (chatCellNodePrefab);
		chatCellNode.GetComponent<chatCellNodeManager> ().setName (name);
		chatCellNode.GetComponent<chatCellNodeManager> ().setMessage (mes);
		chatCellNode.GetComponent<chatCellNodeManager> ().setDirection (direction);
		//chatCellNode.transform.parent = scrollViewContent.transform;
		chatCellNode.transform.SetParent (scrollViewContent.transform);

		cells.Add (chatCellNode);

		float sumHeight = 0;
		float margin = 20;
		for (int i = cells.Count-1; i >= 0; i--) {
			float cellHeight = cells [i].GetComponent<RectTransform> ().sizeDelta [1];
			sumHeight += cellHeight + margin;
		}

		if (800 < sumHeight) {
			scrollViewContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, sumHeight + 40);
		} else {
			scrollViewContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 800);
		}

		float adjustHeight = sumHeight - 840;

		sumHeight = 0;
		for (int i = cells.Count-1; i >= 0; i--) {
			cells [i].transform.localScale = new Vector3 (1, 1, 1);
			cells [i].GetComponent<RectTransform>().localPosition = new Vector3 (350,sumHeight - 740 - adjustHeight,0);
			float cellHeight = cells [i].GetComponent<RectTransform> ().sizeDelta [1];
			sumHeight += cellHeight + margin;
		}

		float autoScrollHeight = scrollViewContent.GetComponent<RectTransform> ().sizeDelta [1] - scrollView.GetComponent<RectTransform> ().sizeDelta [1];
		if (autoScrollHeight > 0) {
			scrollViewContent.GetComponent<RectTransform> ().localPosition = new Vector3 (0, autoScrollHeight, 0);
		}
	}

	public void sendMessage() {
		if (messageInputField.text.Length > 0) {
			addMessage (PlayerPrefs.GetString("name"), messageInputField.text, chatCellNodeManager.BalloonDirection.Right);
			messageInputField.text = "";
		}
	}

	// Use this for initialization
	void Start () {
		Role role = (Role)PlayerPrefs.GetInt ("role");
		cells = new List<GameObject> ();

		addMessage ("GM", "０日目の夜になりました。", chatCellNodeManager.BalloonDirection.Left);
		addMessage ("GM", utility.getRoleInfo(role)["firstNightMessage"],chatCellNodeManager.BalloonDirection.Left);
		addMessage ("Player 2", "よろしく。", chatCellNodeManager.BalloonDirection.Left);
		addMessage ("Player 1", "こちらこそ。", chatCellNodeManager.BalloonDirection.Right);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
