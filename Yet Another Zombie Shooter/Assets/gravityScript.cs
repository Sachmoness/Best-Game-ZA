using UnityEngine;
using System.Collections;

public class gravityScript : MonoBehaviour {


	void Start () 
	{
		
	}
	

	void Update () 
	{
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 3);
	}
}
