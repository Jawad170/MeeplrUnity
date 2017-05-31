using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome_Login : MonoBehaviour {

	public string SceneToOpen = "";

	public Material MaterialNormal	   ;
	public Material MaterialHighlighted;

	void OnMouseDown()
	{
		GetComponent<MeshRenderer> ().material = MaterialHighlighted;
	}

	void OnMouseUp()
	{
		GetComponent<MeshRenderer> ().material = MaterialNormal;
		if ( !SceneToOpen.Equals("") ) SceneManager.LoadScene (SceneToOpen);
	}
}
