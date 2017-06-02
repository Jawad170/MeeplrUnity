using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour {

	public float 		Clamp 					= 0.0f ;
	public float 		Speed 					= 1.0f ;
	public float 		SnapSpeed				= 0.1f ;
	public GameObject 	SelectedText				   ;
	public string[] 	GamesInCarousel				   ;
	[Header("Development Tools")	]
	public bool 		DebugMode 				= false;

	private Vector3 	MousePositionOnClick 		   ;
	private bool 		moving 					= false;
	private bool 		snap 					= false;
	private float 		snapTo 					= 0.0f ;

	void FixedUpdate () 
	{
		if (moving) 
		{
			float xOffset = Input.mousePosition.x - MousePositionOnClick.x;
			float newXPos = gameObject.transform.position.x + (xOffset * Time.deltaTime * Speed);

			Vector3 newPos = new Vector3 (newXPos, gameObject.transform.position.y, gameObject.transform.position.z);

			if ( newXPos < Clamp && newXPos > -Clamp ) gameObject.transform.position = newPos;

			MousePositionOnClick = Input.mousePosition;
		}
		if (snap) 
		{
			float startX = gameObject.transform.position.x;

			float newX = Mathf.Lerp (startX, snapTo, SnapSpeed);

			Vector3 newPos = new Vector3 (newX, gameObject.transform.position.y, gameObject.transform.position.z);

			gameObject.transform.position = newPos;

			if (newX == snapTo) 
			{
				snap = false;
				Vector3 endPos = new Vector3 (snapTo, gameObject.transform.position.y, gameObject.transform.position.z);
				gameObject.transform.position = endPos;
			}
		}
	}

	void OnMouseDown()
	{
		if (DebugMode) Debug.Log ("Carousel: Clicked Down.");

		moving = true ;
		snap   = false;

		MousePositionOnClick = Input.mousePosition;
	}

	void OnMouseUp()
	{
		if (DebugMode) Debug.Log ("Carousel: Clicked Up.");
		moving = false;

		Snap ();
	}

	private void Snap()
	{
		float distans = 9999.0f;
		float closest = 0.0f   ;

		snap = true;

		for (float i = 0.0f; i <= 90.0f; i += 9.0f) 
		{
			if (Mathf.Abs((gameObject.transform.position.x - i)) < distans) 
			{
				distans = Mathf.Abs((gameObject.transform.position.x - i));
				closest = i;
			}
		}
		for (float i = 0.0f; i >= -90.0f; i -= 9.0f) 
		{
			if (Mathf.Abs((gameObject.transform.position.x - i)) < distans) 
			{
				distans = Mathf.Abs((gameObject.transform.position.x - i));
				closest = i;
			}
		}

		if (closest == -18.0f) SelectedText.GetComponent<TextMesh>().text = GamesInCarousel [0];
		if (closest == -9.00f) SelectedText.GetComponent<TextMesh>().text = GamesInCarousel [1];
		if (closest ==  0.00f) SelectedText.GetComponent<TextMesh>().text = GamesInCarousel [2];
		if (closest ==  9.00f) SelectedText.GetComponent<TextMesh>().text = GamesInCarousel [3];
		if (closest ==  18.0f) SelectedText.GetComponent<TextMesh>().text = GamesInCarousel [4];

		snapTo = closest;
	}
}
