using UnityEngine;
using System.Collections;

public class playerMoveScript : MonoBehaviour {

	public float playerMoveSpeed;

	public GameObject modelAnimationObject;
	public GameObject shadowsAnimationObject;

	private Animator modelAnimator;
	private Animator shadowAnimator;

	public static playerMoveScript Instance;
	public bool isWalking;

	void Start () 
	{
		Instance = this;
		modelAnimator = modelAnimationObject.GetComponent<Animator> ();
		shadowAnimator = shadowsAnimationObject.GetComponent<Animator> ();
	}
	

	void Update () 
	{
		

		if (Input.GetAxis ("Horizontal") > 0 || Input.GetAxis ("Horizontal") < 0 || Input.GetAxis ("Vertical") > 0 || Input.GetAxis ("Vertical") < 0)
		{
			movement ();
			isWalking = true;
		} 

		else 
		{
			isWalking = false;
		}

		PlayAnimation ();
			

	}

	void movement()
	{
		


		// Tweaked the movements to negate unwanted speed boosts due to values multiplying from diagonal movement.


		if (Input.GetAxis ("Horizontal") != 0 && Input.GetAxis ("Vertical") != 0) 
		{

			//Played around with the multipliar, and 1.15f seems to be the smoothest compensation value
			transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0)*Time.deltaTime*(playerMoveSpeed/1.15f));

		}

		else
		{
			transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0)*Time.deltaTime*playerMoveSpeed);
		}
			
			
		//transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0)*Time.deltaTime*playerMoveSpeed);
			
	}

	void PlayAnimation()
	{
		if (isWalking) 
		{
			modelAnimator.SetBool ("Walking", true);
			shadowAnimator.SetBool ("Walking", true);
		}

		else
		{
			modelAnimator.SetBool ("Walking", false);
			shadowAnimator.SetBool ("Walking", false);
		}

	}
}
