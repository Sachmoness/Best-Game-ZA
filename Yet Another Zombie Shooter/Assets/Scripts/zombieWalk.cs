using UnityEngine;
using System.Collections;

public class zombieWalk : MonoBehaviour {

	GameObject PlayerObject;

	public float walkSpeed;

	// Use this for initialization
	void Start () {
		PlayerObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		Move ();
	}

	void Move()
	{
		transform.Translate (Vector3.up*Time.deltaTime*walkSpeed);
	}
}
