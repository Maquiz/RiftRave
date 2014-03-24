using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JoinConstants{
	public const string BOX = "BOX";
	public const string JOIN = "JOIN";
	public const string MAINMENU = "MAINMENU";
	public const string JOINRANDOM = "JOINRANDOM";
}

public class GUIJoin : MonoBehaviour {

	private GUIManager gm;
	private Vector2 scroll;
	private string buttonName;
	public string[] names;

	public Vector4 scale;

	void Start () {
		buttonName = "";
		scroll = Vector2.zero;
		gm = new GUIManager (GUIMasterController.instance.skin);
		gm.OnClick += HandleOnClick; //0.335, 0.245
		gm.CreateGUIObject(JoinConstants.BOX,"",new Rect (0.105f*Screen.width, 0.245f*Screen.height, 650.0f, 300.0f), GUIType.Label, "label");
		gm.CreateGUIObject(JoinConstants.MAINMENU, "Main Menu", new Rect (0.125f*Screen.width, 0.6f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.CreateGUIObject(JoinConstants.JOINRANDOM, "Join Random", new Rect (0.379f*Screen.width, 0.6f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.CreateGUIObject(JoinConstants.JOIN, "Join", new Rect (0.63f*Screen.width, 0.6f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
	}

	void HandleOnClick (object sender, ButtonName e)
	{
		switch (e.name) {
			case JoinConstants.JOIN:
				//PhotonNetwork.JoinRoom(buttonName);
				break;
			case JoinConstants.MAINMENU:
				GUIMasterController.instance.state = GUIRenderState.Menu;
				break;	
		}
	}

	void OnGUI () {
		if (!GUIMasterController.instance.state.Equals (GUIRenderState.Join)) return;

		gm.RenderGUIObjects (gm);
		scroll = GUI.BeginScrollView (new Rect (0.125f * Screen.width, 0.245f * Screen.height+25.0f, 250.0f, 0.27f*Screen.height), scroll, new Rect (0.0f,0.0f, 200.0f, 25.0f*names.Length));
		int i = 0;
		foreach (string name in names) {
			if(buttonName == name) GUI.Button (new Rect (0.0f, i++ * 25.0f, 250.0f, 25.0f), name, GUIMasterController.instance.skin.GetStyle ("selected"));
			else{
				if (GUI.Button (new Rect (0.0f, i++ * 25.0f, 250.0f, 25.0f), name, GUIMasterController.instance.skin.GetStyle ("button"))) {
					buttonName = name;
				}
			}
		}
		GUI.EndScrollView ();

	}
}
