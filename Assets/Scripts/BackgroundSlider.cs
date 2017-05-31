using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlider : MonoBehaviour {

	public float xStart = 1.0f ;
	public float xEnd   = 9.0f ;
	public float Speed  = 1.0f ;

	private bool rev    = false;

	void Start()
	{
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
}
