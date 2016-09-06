using UnityEngine;
using System.Collections;

public class cameraFollowPlayer : MonoBehaviour {


	public float cameraMoveSpeed;

	private float originalZ;

	void Start () 
	{
		originalZ = transform.position.z;
	}
	

	void Update () 
	{
		followPlayer ();
	}

	void followPlayer()
	{
		float playerDistance=Vector3.Distance(transform.position,playerMoveScript.Instance.transform.position);


		transform.position= Vector3.Lerp(transform.position, playerMoveScript.Instance.transform.position, cameraMoveSpeed*Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, transform.position.y, originalZ);
	}
}
