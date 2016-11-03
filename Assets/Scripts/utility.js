#pragma strict
import UnityEngine;
static function createClientId(){

	var c = "abcdefghijklmnopqrstrvwxyz0123456789";
	var cl = c.length;
	var clientId ="";
	for(var i = 0; i < 16;i++){
		clientId += c[Random.Range(0,cl-1)];
	}
	return clientId;
}


function Start () {

}

function Update () {

}