using UnityEngine;
using System.Collections;

public class followCrossHair : MonoBehaviour {

	private Vector3 mousePos;

	private Vector3 playerToMouseDirection;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		mousePos = Camera.main.WorldToScreenPoint (Input.mousePosition);

		mousePos.z = 5;
		playerToMouseDirection = mousePos - transform.position;


		rotateTo ();
	}

	void rotateTo()
	{
		
		transform.localRotation = Quaternion.LookRotation (transform.forward, playerToMouseDirection);
		

	}	
}
