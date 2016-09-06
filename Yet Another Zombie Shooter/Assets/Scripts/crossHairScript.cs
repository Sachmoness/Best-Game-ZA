using UnityEngine;
using System.Collections;

public class crossHairScript : MonoBehaviour {

	private Vector3 Pos;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		Pos = Camera.main.WorldToScreenPoint (Input.mousePosition);
		Debug.Log (Pos);
		//Pos=Input.mousePosition;
		Pos.z = -0.3f;

	

		transform.position = Pos;


	}
}
