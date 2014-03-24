using UnityEngine;
using System.Collections;

public enum GUIRenderState{
	Menu,
	Options,
	Create,
	Join
}

public class GUIMasterController : MonoBehaviour {

	public static GUIMasterController instance{ get; set;}
	public GUIRenderState state;
	public GUISkin skin;

	void Awake () {
		instance = gameObject.GetComponent<GUIMasterController>();
		DontDestroyOnLoad (gameObject);
	}

}
