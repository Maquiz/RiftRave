using UnityEngine;
using System.Collections;

public class ScrollbarTest : MonoBehaviour {

	private GUISkin skin;
	public string[] names;


	private Vector2 sv;
	private string innerText;

	void Start () {
		sv = Vector2.zero;
		innerText = "I like trains";
	}

	void OnGUI(){
		sv = GUI.BeginScrollView(new Rect (0.335f*Screen.width, 0.245f*Screen.height, 250.0f, 300.0f),sv,new Rect(0.0f,0.0f,250.0f,300.0f),false,true);
		innerText = GUI.TextArea (new Rect (0, 0, 100, 120), innerText);
		GUI.EndScrollView ();
	}
}
