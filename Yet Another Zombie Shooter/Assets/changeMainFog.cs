using UnityEngine;
using System.Collections;

public class changeMainFog : MonoBehaviour {

	private bool startFade;

	void Start ()
	{
	
	}
	

	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			startFade = true;

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			startFade = false;

		}
	}
}
