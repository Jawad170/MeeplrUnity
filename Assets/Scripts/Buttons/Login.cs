using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public GameObject 	Username			;
	public GameObject 	Password			;

	public string 		SceneToOpen = ""	;

	public Material 	MaterialNormal	   	;
	public Material 	MaterialHighlighted	;

	public bool 		DebugMode 	= false ;

	private string 		Username_s			;
	private string 		Password_s			;

	void OnMouseUp()
	{
		Username_s = Username.GetComponent<InputField> ().text;
		Password_s = Password.GetComponent<InputField> ().text;

		if (DebugMode) Debug.Log ("Login: Button Clicked");

		AttemptLogin ();
	}

	private void AttemptLogin()
	{
		//DO ALL LOGIN CHECKS HERE

		if (DebugMode) Debug.Log ("Login: Attemping to Login");
		if (DebugMode) Debug.Log ("Login: Username[" + Username_s + "] Password[" + Password_s + "]");

		bool success = true;

		if (success)  	Login_Successful (); 
		else  			Login_Failed 	 (); 
	}

	private void Login_Successful()
	{
		if (DebugMode) Debug.Log ("Login: Login Successful");

		if (!SceneToOpen.Equals (""))
			SceneManager.LoadScene (SceneToOpen);
		else
			Debug.LogError ("Login: Login Successful, but Scene To Open is not set");
	}

	private void Login_Failed()
	{
		if (DebugMode) Debug.Log ("Login: Login Failed");
	}
}
