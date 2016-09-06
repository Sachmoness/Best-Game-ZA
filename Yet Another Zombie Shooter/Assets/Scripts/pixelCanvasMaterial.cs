using UnityEngine;
using System.Collections;

public class pixelCanvasMaterial : MonoBehaviour {


	private Texture2D canvasTexture;

	public int textureHeight;
	public int textureWidth;

	void Start () 
	{
		canvasTexture = new Texture2D (textureHeight, textureWidth);
		canvasTexture.wrapMode = TextureWrapMode.Clamp;

		GetComponent<Renderer> ().material.mainTexture = canvasTexture;


	}
	

	void Update () 
	{
	
	}
}
