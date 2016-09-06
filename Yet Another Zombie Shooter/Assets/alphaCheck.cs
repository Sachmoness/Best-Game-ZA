using UnityEngine;
using System.Collections;

public class alphaCheck : MonoBehaviour {



	void Start () 
	{
		Color Material=GetComponent<Renderer> ().material.color;

		GetComponent<Renderer> ().material.color = new Color (Material.a, Material.g, Material.b, 1);
		GetComponent<Renderer> ().sortingOrder = 2;


	}
	

	void Update () 
	{
	
	}
}
