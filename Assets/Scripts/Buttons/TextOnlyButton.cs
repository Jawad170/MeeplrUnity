using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextOnlyButton : MonoBehaviour {
	
	public string 		SceneToOpen = ""	;
	public GameObject 	TheText				;
	public Color 		ColorNormal		   	;
	public Color 		ColorHighlighted  	;

	void OnMouseDown()
	{
		TheText.GetComponent<TextMesh> ().color = ColorHighlighted;
	}

	void OnMouseUp()
	{
		TheText.GetComponent<TextMesh> ().color = ColorNormal;
		if ( !SceneToOpen.Equals("") ) SceneManager.LoadScene (SceneToOpen);
	}
}
