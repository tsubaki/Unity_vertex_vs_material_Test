using UnityEngine;
using System.Collections;

public class UIWindow : MonoBehaviour
{
	
	private ChangeColor color;
	private FPS fps;
	
	void Start ()
	{
		fps = GetComponent<FPS> ();
		color = GetComponent<ChangeColor> ();
	}
	
	void OnGUI ()
	{
		
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("vertex");
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("noncache")) {
			Application.LoadLevel("mesh");
		}
		if (GUILayout.Button ("cached")) {
			Application.LoadLevel("meshcache");
		}
		GUILayout.EndVertical ();
		GUILayout.Label ("material");
		GUILayout.BeginVertical ();
		if (GUILayout.Button ("noncache")) {
			Application.LoadLevel("material");
		}
		if (GUILayout.Button ("cached")) {
			Application.LoadLevel("materialCache");
		}
		GUILayout.EndVertical ();
		GUILayout.Label (fps.frameRate.ToString ());
		
	}
}
