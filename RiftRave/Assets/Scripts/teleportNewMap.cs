using UnityEngine;
using System.Collections;

public class teleportNewMap : MonoBehaviour {
	public bool MapTeleport = false;
	public Vector3 teleportLocation;
	public string mapName;


	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			if(MapTeleport == true){
				Application.LoadLevel(mapName);
			}
			else{
				other.transform.position = new Vector3(0,1,0);
			}
		}
	}
}
