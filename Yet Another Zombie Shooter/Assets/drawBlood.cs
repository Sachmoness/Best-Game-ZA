using UnityEngine;
using System.Collections;

public class drawBlood : MonoBehaviour {

	private RaycastHit Hit;
	private Vector3 posInTexture;
	private pixelCanvas canvasScript;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		//Forward
		Debug.DrawRay (transform.position, transform.up*3, Color.red);


		//Down
		Debug.DrawRay (transform.position, transform.forward*3, Color.red);


		if (Input.GetKeyDown ("space")) 
		{
			prototypeBloodPosition();
		}

		if (Input.GetKeyDown ("mouse 0")) 
		{
			prototypeBloodDirection();
		}

		if (Input.GetKeyDown ("mouse 1")) 
		{
			refBloodDirection();
		}

		if (Input.GetKeyDown ("t")) 
		{
			refBloodPosition();
		}

	}

	void prototypeBloodDirection()
	{
		if(Physics.Raycast(transform.position, transform.up*3,out Hit))
		{

			if(Hit.collider.tag=="buildingFace")
			{
				
				
				posInTexture = Hit.textureCoord;
				
				
				//textureCoord returns floats, there it is multiplied by the width and height for proportions 
				posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
				posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;
				
				// The Canvas script is defined, and a public function is called
				canvasScript = Hit.collider.GetComponent<pixelCanvas>();
				canvasScript.ballisticDeathBuilding (posInTexture);
			}

		}
	}

	void refBloodDirection()
	{
		if(Physics.Raycast(transform.position, transform.up*3,out Hit))
		{

			if(Hit.collider.tag=="buildingFace")
			{
				Debug.Log("Building Blood");

				posInTexture = Hit.textureCoord;


				//textureCoord returns floats, there it is multiplied by the width and height for proportions 
				posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
				posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;

				// The Canvas script is defined, and a public function is called
				canvasScript = Hit.collider.GetComponent<pixelCanvas>();
				canvasScript.stencilTest (posInTexture);
			}

		}

	}

	void refBloodPosition()
	{
		if(Physics.Raycast(transform.position, transform.forward,out Hit))
		{
			Debug.Log("Floor Blood");

			posInTexture = Hit.textureCoord;


			//textureCoord returns floats, there it is multiplied by the width and height for proportions 
			posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
			posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;

			// The Canvas script is defined, and a public function is called
			canvasScript = Hit.collider.GetComponent<pixelCanvas>();

			if (Hit.collider.tag == "sideWalk") 
			{
				
				canvasScript.pavementSpatter (posInTexture);

			} 
			else 
			{
				canvasScript.stencilTest (posInTexture);
			}

		}


	}


	void prototypeBloodPosition()
	{
		if(Physics.Raycast(transform.position, transform.forward,out Hit))
		{
			Debug.Log("Floor Blood");

			posInTexture = Hit.textureCoord;
			
			
			//textureCoord returns floats, there it is multiplied by the width and height for proportions 
			posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
			posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;
			
			// The Canvas script is defined, and a public function is called
			canvasScript = Hit.collider.GetComponent<pixelCanvas>();


			if (Hit.collider.tag == "sideWalk") 
			{

				canvasScript.pavementExplosion (posInTexture);

			} 
			else 
			{
				canvasScript.explosionStencil (posInTexture);
			}
		}
	}
}
