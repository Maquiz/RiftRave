using UnityEngine;
using System.Collections;

public class MenuConstants{
	public const string BOX = "BOX";
	public const string JOIN = "JOIN";
	public const string CREATE = "CREATE";
	public const string OPTIONS = "OPTIONS";
	public const string QUIT = "QUIT";
}

public class GUIMenu : MonoBehaviour {

	private GUIManager gm;
	public static GUIMenu instance;

	void Start(){
		instance = gameObject.GetComponent<GUIMenu> ();
		gm = new GUIManager (GUIMasterController.instance.skin);
		gm.OnClick += HandleOnClick;
		gm.CreateGUIObject(MenuConstants.BOX,"",new Rect (0.335f*Screen.width, 0.245f*Screen.height, 250.0f, 300.0f), GUIType.Label, "label");
		gm.CreateGUIObject(MenuConstants.JOIN, "Join Room", new Rect (0.365f*Screen.width, 0.3f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.CreateGUIObject(MenuConstants.CREATE, "Create Room", new Rect (0.365f*Screen.width, 0.4f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		//gm.CreateGUIObject(MenuConstants.OPTIONS, "Options", new Rect (0.365f*Screen.width, 0.5f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.CreateGUIObject(MenuConstants.QUIT, "Quit", new Rect (0.365f*Screen.width, 0.6f*Screen.height, 200.0f, 50.0f), GUIType.Button, "label");
		gm.pointer = "JOIN";
	}

	void HandleOnClick (object sender, ButtonName e)
	{
		switch (e.name) {
			case MenuConstants.JOIN:
				GUIMasterController.instance.state = GUIRenderState.Join;
				break;
			case MenuConstants.CREATE:
				GUIMasterController.instance.state = GUIRenderState.Create;
				break;
			case MenuConstants.OPTIONS:
				break;
			case MenuConstants.QUIT:
				Application.Quit();
				break;
		}
	}

	void OnGUI(){
		if (!GUIMasterController.instance.state.Equals (GUIRenderState.Menu)) return;
		gm.RenderGUIObjects (gm);
	}

}
