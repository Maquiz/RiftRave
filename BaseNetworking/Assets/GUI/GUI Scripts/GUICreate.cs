using UnityEngine;
using System.Collections;

public class CreateConstants{

	public const string BOX = "BOX";
	public const string TEXTBOX = "TEXTBOX";
	public const string CREATE = "CREATE";
	public const string MAINMENU = "MAINMENU";
	public const string STATUS = "STATUS";
}

public class GUICreate : MonoBehaviour {

	public static GUICreate instance;
	private GUIManager gm;

	void Start () {
		instance = gameObject.GetComponent<GUICreate> ();
		gm = new GUIManager (GUIMasterController.instance.skin);
		gm.OnClick += HandleOnClick;
		gm.CreateGUIObject(CreateConstants.BOX,"",new Rect (0.335f*Screen.width, 0.245f*Screen.height, 250.0f, 300.0f), GUIType.Label, "label");
		gm.CreateGUIObject (CreateConstants.TEXTBOX, "", new Rect (0.365f * Screen.width, 0.3f * Screen.height, 200.0f, 50.0f), GUIType.TextField, "label");
		gm.CreateGUIObject(CreateConstants.STATUS, "Enter Name", new Rect (0.365f*Screen.width, 0.4f*Screen.height, 200.0f, 50.0f), GUIType.Button, "textfield");
		gm.CreateGUIObject(CreateConstants.CREATE, "Create", new Rect (0.365f*Screen.width, 0.5f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.CreateGUIObject(CreateConstants.MAINMENU, "Main Menu", new Rect (0.365f*Screen.width, 0.6f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
	}

	void HandleOnClick (object sender, ButtonName e)
	{
		switch (e.name) {
			case CreateConstants.CREATE:
				break;
			case CreateConstants.MAINMENU:
				GUIMasterController.instance.state = GUIRenderState.Menu;
				break;
		}
	}

	void OnGUI(){
		if (!GUIMasterController.instance.state.Equals (GUIRenderState.Create)) return;
		gm.RenderGUIObjects (gm);
	}
	
}
