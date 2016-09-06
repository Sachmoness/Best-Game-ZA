using UnityEngine;
using System.Collections;

public class secondLevelAlphaScript : MonoBehaviour {


	public bool isIn;

	private Color Material;


	void Start () 
	{
		Material = transform.parent.GetComponent<Renderer> ().material.color;

		transform.parent.GetComponent<Renderer> ().material.color = new Color (Material.a, Material.g, Material.b, 1);
		transform.parent.GetComponent<Renderer> ().sortingOrder = 2;
	}


	void Update () 
	{
		roofFade (isIn);	

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			isIn = true;

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			isIn = false;

		}
	}

	void roofFade(bool In)
	{
		if (In && transform.parent.GetComponent<Renderer>().material.color.a>=0 ) 
		{
			transform.parent.GetComponent<Renderer>().material.color-=new Color (0, 0, 0, 0.01f);
		}

		if ((!In && transform.parent.GetComponent<Renderer>().material.color.a<=1)) 
		{
			transform.parent.GetComponent<Renderer>().material.color+=new Color (0, 0, 0, 0.015f);
		}
	}
}
