using UnityEngine;
using System.Collections;

public class clickPosition : MonoBehaviour {

	private RaycastHit Hit;

	private Vector2 posInTexture;

	private pixelCanvas textureScriptPaint;

	public bool allowDebugPaintMode;

	void Start ()
	{
	
	}
	

	void Update () 
	{
		if (Input.GetKey ("mouse 0")) 
		{

			mousePosition ();
		}

		if (Input.GetKey ("mouse 1")) 
		{

			mousePositionTwo ();
		}
	
	}

	void mousePosition()
	{
		//Ray is casted from object to the canvas plane


		if (Physics.Raycast (transform.position, transform.forward, out Hit))
		{

			//textureCoord() gets the exact poit on the object's mesh. It is important that the plane object has a mesh collider
			posInTexture = Hit.textureCoord;


			//textureCoord returns floats, there it is multiplied by the width and height for proportions 
			posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
			posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;

			// The Canvas script is defined, and a public function is called
			textureScriptPaint = Hit.collider.GetComponent<pixelCanvas>();
			textureScriptPaint.ballisticDeath (posInTexture);
		}
			
		
	}

	void mousePositionTwo()
	{

		if (Physics.Raycast (transform.position, transform.forward, out Hit))
		{
			posInTexture = Hit.textureCoord;

			posInTexture.x*= Hit.collider.GetComponent<Renderer>().material.mainTexture.width;
			posInTexture.y*= Hit.collider.GetComponent<Renderer>().material.mainTexture.height;
			textureScriptPaint = Hit.collider.GetComponent<pixelCanvas>();
			textureScriptPaint.mousePaint (posInTexture);
		}


	}


}
