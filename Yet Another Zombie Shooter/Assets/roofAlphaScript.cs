using UnityEngine;
using System.Collections;

public class roofAlphaScript : MonoBehaviour {

	public bool isIn;

	private Color Material;
	private GameObject playerObject;

	void Start () 
	{
		Material = transform.parent.GetComponent<Renderer> ().material.color;

		transform.parent.GetComponent<Renderer> ().material.color = new Color (Material.a, Material.g, Material.b, 1);
		transform.parent.GetComponent<Renderer> ().sortingOrder = 2;
	}
	

	void Update () 
	{
		if (playerObject) 
		{
			roofFade (isIn);	
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player") 
		{
			isIn = true;
			playerObject = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			isIn = false;
			playerObject = other.gameObject;
		}
	}

	void roofFade(bool In)
	{
		if (In && transform.parent.GetComponent<Renderer>().material.color.a>=0 && playerObject.transform.position.z>=-2.5f) 
		{
			transform.parent.GetComponent<Renderer>().material.color-=new Color (0, 0, 0, 0.01f);
		}

		if ((!In && transform.parent.GetComponent<Renderer>().material.color.a<=1) || (playerObject.transform.position.z<=-2.5f && transform.parent.GetComponent<Renderer>().material.color.a<=1)) 
		{
			transform.parent.GetComponent<Renderer>().material.color+=new Color (0, 0, 0, 0.015f);
		}
	}

}
