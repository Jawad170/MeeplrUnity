using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host_GameButton : MonoBehaviour {

	public string 	Title;
	public Material Logo ;

	public GameObject SelectedText;

	void OnMouseDown()
	{
		SelectedText.GetComponent<TextMesh> ().text = Title;
	}

	public void Set(string Title, Material Logo)
	{
		this.Title = Title;
		this.Logo  = Logo ;
	}
}
