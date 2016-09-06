using UnityEngine;
using System.Collections;

public class pixelCanvas : MonoBehaviour {

	// isWhite is used to check if the pixels should be applied to a cloned custom texture, or to a made texture(dynamic)

	private bool isWhite;

	private Texture2D Clone;

	private Color[] canvasPixels;

	public Texture2D canvasTexture;
	public int textureHeight;
	public int textureWidth;
	public Texture2D[] testStencil;
	public Texture2D explosionBrush;
	public Texture2D pavementBrush;
	public Texture2D pavementExplosionBrush;


	/*---------------------------------------------------

	if a custom texture is being used, you will have to 
	change the following inspector properties for it to work
	with setPixel()

	TextureType: Advanced;

	Read/Write Enabled: True;
	
	override for pc, mac and linux: True;

	
	Format: ARGB 32 bit


	---------------------------------------------------*/







	void Start () 
	{
		// Checking to see if the object has a texture

		//If so, a texture is made and applied to the renderer

		if (!GetComponent<Renderer> ().material.mainTexture) 
		{
			canvasTexture = new Texture2D (textureHeight, textureWidth);
			canvasTexture.wrapMode = TextureWrapMode.Clamp;
			GetComponent<Renderer> ().material.mainTexture = canvasTexture;

			isWhite = true;
		}


		//If there is a custom texture on, the statement clones the texture to prevent drawing pixels globally/to the disk

		else 
		{
			Clone = Instantiate (GetComponent<Renderer> ().material.mainTexture) as Texture2D;
			GetComponent<Renderer> ().material.mainTexture = Clone;

			isWhite = false;
		}
			

		


	}


	/*---------------------------------------------------

	All blood spatters are slightly offset 

	This is compensated by adjusting the ray.object's 
	position in the scene


	---------------------------------------------------*/

	public void pavementSpatter(Vector2 uvPos)
	{
		//Randomly going through custom texture array to draw variety 
		int randomBrush = Random.Range (0, testStencil.Length);


		//Getting pixels from source image (Image being used as stencil)
		Color[] imageArray= pavementBrush.GetPixels(); 

		//2D For loop to navigate UV coordinates
		for (int x = 0; x < pavementBrush.width; x++) 
		{
			for (int y = 0; y < pavementBrush.height; y++) 
			{
				//GetPixel stores color in a 1D array, therefore navigating requires some math
				//In equation, x is the column index, and the y multipliar is for the rows
				//Math was found online, I'm not smart.
				Color imagePixel = imageArray [x + (y * pavementBrush.width)];

				if (imagePixel.a != 0) 
				{
					if (isWhite) 
					{
						canvasTexture.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);
					}

					else
						Clone.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);

				}


			}
		}

		//canvasTexture.SetPixels (colourArray);


		if (isWhite)
		{
			canvasTexture.Apply ();
		} 

		else
			Clone.Apply ();
	}

	public void pavementExplosion(Vector2 uvPos)
	{
		//Randomly going through custom texture array to draw variety 
		int randomBrush = Random.Range (0, testStencil.Length);


		//Getting pixels from source image (Image being used as stencil)
		Color[] imageArray= pavementExplosionBrush.GetPixels(); 

		//2D For loop to navigate UV coordinates
		for (int x = 0; x < pavementExplosionBrush.width; x++) 
		{
			for (int y = 0; y < pavementExplosionBrush.height; y++) 
			{
				//GetPixel stores color in a 1D array, therefore navigating requires some math
				//In equation, x is the column index, and the y multipliar is for the rows
				//Math was found online, I'm not smart.
				Color imagePixel = imageArray [x + (y * pavementExplosionBrush.width)];

				if (imagePixel.a != 0) 
				{
					if (isWhite) 
					{
						canvasTexture.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-100, imagePixel);
					}

					else
						Clone.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-100, imagePixel);

				}


			}
		}

		//canvasTexture.SetPixels (colourArray);


		if (isWhite)
		{
			canvasTexture.Apply ();
		} 

		else
			Clone.Apply ();
	}


	public void stencilTest(Vector2 uvPos)
	{

		//Randomly going through custom texture array to draw variety 
		int randomBrush = Random.Range (0, testStencil.Length);


		//Getting pixels from source image (Image being used as stencil)
		Color[] imageArray= testStencil[randomBrush].GetPixels(); 

		//2D For loop to navigate UV coordinates
		for (int x = 0; x < testStencil[randomBrush].width; x++) 
		{
			for (int y = 0; y < testStencil[randomBrush].height; y++) 
			{
				//GetPixel stores color in a 1D array, therefore navigating requires some math
				//In equation, x is the column index, and the y multipliar is for the rows
				//Math was found online, I'm not smart.
				Color imagePixel = imageArray [x + (y * testStencil[randomBrush].width)];

				if (imagePixel.a != 0) 
				{
					if (isWhite) 
					{
						canvasTexture.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);
					}

					else
						Clone.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);

				}


			}
		}

		//canvasTexture.SetPixels (colourArray);


		if (isWhite)
		{
			canvasTexture.Apply ();
		} 

		else
			Clone.Apply ();



	}

	public void explosionStencil(Vector2 uvPos)
	{
		//Randomly going through custom texture array to draw variety 
		int randomBrush = Random.Range (0, testStencil.Length);


		//Getting pixels from source image (Image being used as stencil)
		Color[] imageArray= explosionBrush.GetPixels(); 

		//2D For loop to navigate UV coordinates
		for (int x = 0; x < explosionBrush.width; x++) 
		{
			for (int y = 0; y < explosionBrush.height; y++) 
			{
				//GetPixel stores color in a 1D array, therefore navigating requires some math
				//In equation, x is the column index, and the y multipliar is for the rows
				//Math was found online, I'm not smart.
				Color imagePixel = imageArray [x + (y * explosionBrush.width)];

				if (imagePixel.a != 0) 
				{
					if (isWhite) 
					{
						canvasTexture.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);
					}

					else
						Clone.SetPixel (x+(int)uvPos.x-60, y+(int)uvPos.y-50, imagePixel);

				}


			}
		}

		//canvasTexture.SetPixels (colourArray);


		if (isWhite)
		{
			canvasTexture.Apply ();
		} 

		else
			Clone.Apply ();
	}


	// Public function that is called by clickPosition(class)

	public void mousePaint(Vector2 uvPos)
	{

		if (isWhite) 
		{

			//Loop is used to draw the pixels

			for (int i = 0; i < 2; i++) 
			{

				for (int j = 0; j < 2; j++) 
				{
					
					//texture2D.SetPixel(UV coordinate X, UV coordinate Y, Color)
					//texture2D.SetPixel replaces pixels, therefore the alpha value is having no effect
					//I'm going to work on blending the origninal pixel with the drawn pixel to simulate transparency. Wish me luck

					canvasTexture.SetPixel ((int)uvPos.x + i, (int)uvPos.y + j, new Color(153,0,0,0.5f));


					//texture2D.Apply has process lag time of 0.01 second. Will use 300x300 resolution textures for now.
					//Need to use texture2D.Apply() after drawing pixels


					canvasTexture.Apply ();

				}
			}


		}


		//Same functionality as above, except it is applied to an object that has a custom texture

		if (!isWhite) 
		{
			for (int i = 0; i < 2; i++) 
			{

				for (int j = 0; j < 2; j++) 
				{
					Clone.SetPixel ((int)uvPos.x+i, (int)uvPos.y+j, new Color(153,0,0,0.5f));

					Clone.Apply ();
				}
			}
		}


	}



	public void ballisticDeath(Vector2 uvPos)
	{

		// So drawing pixels can be quite a tedious effect
		// Below is an example of a blood spatter I created
		// If you want to learn this shit, I suggest creating and testing each for loop individually
		// Each loop has some effect, the one is the light blood spatter, and the other heavy wide blood spatter
		// It's quite shit to do, I'm going to try work on a brush stencil method with GetPixel();

		for(int i= -20; i<20;i++)
		{
			int randomNumber= Random.Range(-20,20);
			int randomNumber2= Random.Range(-20,20);

			if (isWhite) 
			{
				canvasTexture.SetPixel ((int)uvPos.x+randomNumber+i, (int)uvPos.y+randomNumber2+i, new Color(153,0,0,0.5f));
			}

			if (!isWhite) 
			{
				Clone.SetPixel ((int)uvPos.x+randomNumber+i, (int)uvPos.y+randomNumber2+i, new Color(153,0,0,0.5f));
			}



		}

		for(int i=0; i<15; i++)
		{
			///////////////////////////////////////////////////////////////////////
			// Below is function for medium scattered range spatters 

			int randomNumber= Random.Range(-20,15);
			int randomNumber2= Random.Range(-20,15);

			for(int j=-1; j<1; j++)
			{


				for(int k=-1; k<1; k++)
				{

					if (isWhite) 
					{
						canvasTexture.SetPixel ((int)uvPos.x+randomNumber+j, (int)uvPos.y+randomNumber2+k, new Color(153,0,0,0.5f));
					}

					if (!isWhite) 
					{
						Clone.SetPixel ((int)uvPos.x+randomNumber+j, (int)uvPos.y+randomNumber2+k, new Color(153,0,0,0.5f));
					}


				}
			}

			for(int l=-2;l<2;l++)
			{

				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}

				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}



			}


			for(int m=-2;m<2;m++)
			{
				

				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}

				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
			}
			//////////////////////////////////////////////////////////////////////////

			/////////////////////////////////////////////////////////////////////////
			// Below is function for concentrated range spatters (close in proximity)

			randomNumber= Random.Range(-5,5);
			randomNumber2= Random.Range(-5,5);


			for(int l=-2;l<2;l++)
			{
				

				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}

				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}

			}


			for(int m=-2;m<2;m++)
			{
				

				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}

				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
			}

		}



		if (isWhite) 
		{
			
			canvasTexture.Apply ();

		}

		if (!isWhite) 
		{
			Clone.Apply ();
		}

	}

	public void ballisticDeathBuilding(Vector2 uvPos)
	{
		
		// So drawing pixels can be quite a tedious effect
		// Below is an example of a blood spatter I created
		// If you want to learn this shit, I suggest creating and testing each for loop individually
		// Each loop has some effect, the one is the light blood spatter, and the other heavy wide blood spatter
		// It's quite shit to do, I'm going to try work on a brush stencil method with GetPixel();
		
		for(int i= -30; i<30;i++)
		{
			int randomNumber= Random.Range(-50,50);
			int randomNumber2= Random.Range(-50,50);
			
			if (isWhite) 
			{
				for(int j=0;j<2;j++)
				{
					for(int k=0; k<2;k++)
					{
						canvasTexture.SetPixel ((int)uvPos.x+randomNumber+i+j, (int)uvPos.y+randomNumber2+i+k, new Color(153,0,0,0.5f));
					}

				}

			}
			
			if (!isWhite) 
			{
				for(int j=0;j<2;j++)
				{
					for(int k=0; k<2;k++)
					{
						Clone.SetPixel ((int)uvPos.x+randomNumber+i+j, (int)uvPos.y+randomNumber2+i+k, new Color(153,0,0,0.5f));
					}
					
				}
			}
			
			
			
		}
		
		for(int i=0; i<25; i++)
		{
			///////////////////////////////////////////////////////////////////////
			// Below is function for medium scattered range spatters 
			
			int randomNumber= Random.Range(-30,25);
			int randomNumber2= Random.Range(-30,25);
			
			for(int j=-2; j<2; j++)
			{
				
				
				for(int k=-2; k<2; k++)
				{
					
					if (isWhite) 
					{
						canvasTexture.SetPixel ((int)uvPos.x+randomNumber+j, (int)uvPos.y+randomNumber2+k, new Color(153,0,0,0.5f));
					}
					
					if (!isWhite) 
					{
						Clone.SetPixel ((int)uvPos.x+randomNumber+j, (int)uvPos.y+randomNumber2+k, new Color(153,0,0,0.5f));
					}
					
					
				}
			}
			
			for(int l=-2;l<2;l++)
			{
				
				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}
				
				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}
				
				
				
			}
			
			
			for(int m=-2;m<2;m++)
			{
				
				
				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
				
				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
			}
			//////////////////////////////////////////////////////////////////////////
			
			/////////////////////////////////////////////////////////////////////////
			// Below is function for concentrated range spatters (close in proximity)
			
			randomNumber= Random.Range(-10,10);
			randomNumber2= Random.Range(-10,10);
			
			
			for(int l=-2;l<2;l++)
			{
				
				
				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}
				
				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber+l, (int)uvPos.y+randomNumber2, new Color(153,0,0,0.5f));
				}
				
			}
			
			
			for(int m=-2;m<2;m++)
			{
				
				
				if (isWhite) 
				{
					canvasTexture.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
				
				if (!isWhite) 
				{
					Clone.SetPixel ((int)uvPos.x+randomNumber, (int)uvPos.y+randomNumber2+m, new Color(153,0,0,0.5f));
				}
			}
			
		}
		
		
		
		if (isWhite) 
		{
			
			canvasTexture.Apply ();
			
		}
		
		if (!isWhite) 
		{
			Clone.Apply ();
		}
		
	}


}
