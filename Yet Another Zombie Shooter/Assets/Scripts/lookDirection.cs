using UnityEngine;
using System.Collections;

public class lookDirection : MonoBehaviour {

	private GameObject playerObject;


	void Start () 
	{
		playerObject = GameObject.FindGameObjectWithTag ("Player").transform.gameObject;
	}
	

	void Update () 
	{
		pointToPlayer ();
	}

	void pointToPlayer()
	{
		Vector3 zombieToPlayerDirection = playerObject.transform.position - transform.position;

		transform.rotation = Quaternion.LookRotation (transform.forward, zombieToPlayerDirection);
	}
}
