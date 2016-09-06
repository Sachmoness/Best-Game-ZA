using UnityEngine;
using System.Collections;

public class followParentFog : MonoBehaviour {

	private roomFogScript fogScript;

	public bool isFade;

	void Start ()
	{
		fogScript = transform.parent.GetChild(0).GetComponent<roomFogScript> ();
	}
	

	void Update ()
	{
		fadeFunction (fogScript.startFade);
	}

	void fadeFunction(bool Fade)
	{
		if ((Fade && transform.parent.GetComponent<Renderer> ().material.color.a>=0) ) 
		{
			GetComponent<Renderer> ().material.color -= new Color (0, 0, 0, 0.01f);
		}

		if (!Fade && transform.parent.GetComponent<Renderer> ().material.color.a<=1 ) 
		{
			GetComponent<Renderer> ().material.color += new Color (0, 0, 0, 0.015f);
		}
	}
}
