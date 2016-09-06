using UnityEngine;
using System.Collections;

public class roomFogScript : MonoBehaviour {

	public bool startFade;
	public bool isNextLevel; // >:)

	private Color spriteColors;

	private GameObject playerObject;

	void Start ()
	{
		spriteColors = transform.parent.GetComponent<Renderer> ().material.color;
	}
	

	void Update () 
	{
		/*if (playerObject) 
		{
			if (playerObject.transform.position.z >= -2.5f) 
			{
				isNextLevel = false;
			}

			if (playerObject.transform.position.z <= -2.5f) 
			{
				isNextLevel = true;
			}

			fadeFunction (startFade);
		}*/

		fadeFunction (startFade);

	}

	void fadeFunction(bool Fade)
	{
		if ((Fade && transform.parent.GetComponent<Renderer> ().material.color.a>=0) /*|| (isNextLevel && transform.parent.GetComponent<Renderer> ().material.color.a>=0)*/) 
		{
			transform.parent.GetComponent<Renderer> ().material.color -= new Color (0, 0, 0, 0.01f);
		}

		if (!Fade && transform.parent.GetComponent<Renderer> ().material.color.a<=1 /*&& !isNextLevel*/) 
		{
			transform.parent.GetComponent<Renderer> ().material.color += new Color (0, 0, 0, 0.015f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			startFade = true;
			playerObject = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			startFade = false;
			playerObject = other.gameObject;
		}
	}
}
