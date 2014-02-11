using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {
	public Texture bumpMap;
	public Transform prefab;
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Instantiate(prefab,this.transform.position, Quaternion.identity);
			renderer.material.SetTexture("Flame", bumpMap);
		}
	}
}
