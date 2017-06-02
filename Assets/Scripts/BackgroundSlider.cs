using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlider : MonoBehaviour {

	[Header("Control Parameters")	]
	public float 		xStart 		= 1.0f 	;
	public float 		xEnd   		= 9.0f 	;
	public float 		Speed  		= 1.0f 	;
	[Header("Possible Backgrounds")	]
	public Material[] 	Mats	   			;
	[Header("Development Tools")	]
	public bool 		DebugMode 	= false	;

	private bool 		rev    		= false ;

	public static bool 	BGChosen 	= false	;

	void Start()
	{
		if (!BGChosen) ChooseMat ();
		else 		   SetMat    ();

		if ( PlayerPrefs.GetFloat("BGSlideX") == 0.0f ) 
			transform.position = new Vector3 (xStart, transform.position.y, transform.position.z);
		else
			transform.position = new Vector3 (PlayerPrefs.GetFloat("BGSlideX"), transform.position.y, transform.position.z);
	}

	void Update () 
	{
		if (transform.position.x < xEnd && !rev) 
		{
			float step = Speed * Time.deltaTime;
			transform.position = new Vector3 (transform.position.x + step, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > xStart) 
		{
			rev = true;
			float step = Speed * Time.deltaTime;
			transform.position = new Vector3 (transform.position.x - step, transform.position.y, transform.position.z);
		}
		else
		{
			rev = false;
		}

		PlayerPrefs.SetFloat ("BGSlideX", transform.position.x);
	}

	public void ChooseMat()
	{
		if (DebugMode) Debug.Log ("BackgroundSlider: BG Mat NOT selected, Rolling . . .");

		int Choice = (int) Random.Range (0, Mats.Length);

		gameObject.GetComponent<MeshRenderer> ().material = Mats [Choice];

		BackgroundSlider.BGChosen = true;

		PlayerPrefs.SetInt ("BGMat", Choice);

		if (DebugMode) Debug.Log ("BackgroundSlider: New BG Mat selected, setting [" + PlayerPrefs.GetInt ("BGMat") + "]");
	}

	public void SetMat()
	{
		if (DebugMode) Debug.Log ("BackgroundSlider: BG Mat already selected, setting [" + PlayerPrefs.GetInt ("BGMat") + "]");

		gameObject.GetComponent<MeshRenderer> ().material = Mats [PlayerPrefs.GetInt("BGMat")];
	}
}
