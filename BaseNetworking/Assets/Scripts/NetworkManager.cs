using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	public const string GAME_VERSION = "0";
	public Camera idleCam;
	
	void Start () {
		DontDestroyOnLoad (gameObject);
		Connect ();
	}

	void Connect(){
		PhotonNetwork.ConnectUsingSettings (GAME_VERSION);
	}

	void OnGUI(){
		//GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		//foreach (RoomInfo room in PhotonNetwork.GetRoomList()) {
		//	GUILayout.Label(room.name + " " + room.playerCount + "/" + room.maxPlayers);
		//}
	}

	void OnJoinedLobby(){
		Debug.Log ("joined lobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("joinedrandom failed");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		Debug.Log ("joinedroom");
		SpawnPlayer ();

	}

	void SpawnPlayer(){
		GameObject player = (GameObject)PhotonNetwork.Instantiate ("Player", Vector3.zero, Quaternion.identity, 0);
		((MonoBehaviour)player.GetComponent("FPSInputController")).enabled = true;
		((MonoBehaviour)player.GetComponent("MouseLook")).enabled = true;
		((MonoBehaviour)player.GetComponent("CharacterMotor")).enabled = true;
		player.transform.FindChild ("Main Camera").gameObject.SetActive (true);
		idleCam.enabled = false;
	}


}
