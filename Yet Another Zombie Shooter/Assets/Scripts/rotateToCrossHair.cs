using UnityEngine;
using System.Collections;

public class rotateToCrossHair : MonoBehaviour {

	private Vector3 playerPosition;
	private Vector3 Direction;
	private Vector3 mousePos;
	private float Angle;

	private Ray ray;

	private float hit;

	public GameObject crosshairSprite;
	private Vector3 _crossfollowVec;

	void Start () 
	{
		Cursor.visible = false;
	}
	

	void LateUpdate ()  //to prevent crosshair jittering LateUpdate used
	{
		aimAtMouse ();

	}

	void aimAtMouse()
	{
		

		/*playerPosition = Camera.main.WorldToScreenPoint (transform.position);

		mousePos = Input.mousePosition;
		mousePos.z = 0;

		Direction = mousePos - playerPosition;

		Angle = Mathf.Atan2 (Direction.y, Direction.x) * Mathf.Rad2Deg;

		//transform.localRotation = Quaternion.AngleAxis (Angle, Vector3.forward);
		transform.rotation= Quaternion.Euler(new Vector3(0,0,Angle));*/


		playerPosition = Camera.main.WorldToScreenPoint (transform.position);

		mousePos = Input.mousePosition;
		mousePos.z = 1.5f;

		_crossfollowVec = Camera.main.ScreenToWorldPoint (mousePos); //make crosshair sprite follow cursor
		crosshairSprite.transform.position = _crossfollowVec;

		Direction = mousePos - playerPosition;

		transform.localRotation = Quaternion.LookRotation (transform.forward, Direction);







	}

}
