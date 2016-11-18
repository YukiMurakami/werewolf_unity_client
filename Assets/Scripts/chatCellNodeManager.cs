using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class chatCellNodeManager : MonoBehaviour {

	public enum BalloonDirection {
		Right,
		Left,
	}

	public Image backgroundImage;
	public Text nameText;
	public Text messageText;


	BalloonDirection balloonDirection;

	public void setName(string name) {
		nameText.text = name;
	}

	public void setMessage(string mes) {
		messageText.text = mes;
	}

	public void setDirection(BalloonDirection direction) {
		balloonDirection = direction;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
