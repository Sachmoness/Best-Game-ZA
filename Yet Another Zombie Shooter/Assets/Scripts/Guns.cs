using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guns : MonoBehaviour {

	public bool Pistol; 
	public bool Shotgun;
	public bool SMG;
	public float reloadTime;

	public GameObject modelAnimationObject;
	public GameObject shadowsAnimationObject;

	private Animator modelAnimator;
	private Animator shadowAnimator;

	float countdown;

	////// Bullet Count

	[Header("")]
	[Header("Bullets Remaining \n-----------------------------------------------------------------------------------------------")]

	public float bulletCount;

	////// Rate of Fire 
	 
	[Header("")]
	[Header("Rate of Fire for various weapons \n-----------------------------------------------------------------------------------------------")]

	public float pistolROF;
	public float SMGROF;
	public float shotgunROF;

	////// Reload

	[Header("")]
	[Header("Reload Times for various weapons \n-----------------------------------------------------------------------------------------------")]
	[Header("")]

	public float pistolReload;
	public float SMGReload;
	public float shotgunReload;

	////// Clip Size

	[Header("")]
	[Header("Clip Sizes for various weapons \n-----------------------------------------------------------------------------------------------")]

	public float pistolClip;
	public float SMGClip;
	public float shotgunClip;

	[Header("-----------------------------------------------------------------------------------------------")]


	public GameObject[] Bullet;
	public GameObject bulletSpawner; 
	public GameObject bulletDirection; 


	public float burst_countdown;

	public bool burst_timer = false;
	public bool reloading = false; 

	Vector3 startPos, shootDirection;
	Quaternion direc;

	public Text Reloading_Text;

	// Use this for initialization
	void Start () 
	{

		modelAnimator = modelAnimationObject.GetComponent<Animator> ();
		shadowAnimator = shadowsAnimationObject.GetComponent<Animator> ();
		
		countdown = reloadTime;

		if (Pistol) 
		{
			burst_countdown = pistolROF;
			countdown = pistolReload;
			bulletCount = pistolClip;
		}

		else if (Shotgun) 
		{
			burst_countdown = shotgunROF;
			countdown = shotgunReload;
			bulletCount = shotgunClip;
		}

		else if (SMG) 
		{
			burst_countdown = SMGROF;
			countdown = SMGReload;
			bulletCount = SMGClip;
		}



		Reloading_Text.gameObject.SetActive(false);
	}

	// Update is called once per frame


	void Update () 
	{

		GunSwitch ();
		GunShoot ();
		RateOfFire ();


		if(Input.GetKeyDown(KeyCode.R) && !reloading)
		{ 
			reloading=true;
		}

		Reload ();

	

	}

	void Spawn()
	{
		Vector3 Direction = bulletDirection.transform.position - transform.position;

		Instantiate (Bullet [0], bulletSpawner.transform.position, Quaternion.LookRotation (transform.forward, Direction));
	}
		

	void Reload()
	{

		if (reloading)
		{ //reload timer

			Debug.Log ("Reloading: " + reloading);

			Reloading_Text.gameObject.SetActive (true);

			if (countdown > 0f) {
				countdown -= Time.deltaTime;

			} 

			else 
			{
				ReloadAndClip ();
			}
			
		} 

		else 
		{
			Reloading_Text.gameObject.SetActive (false);

		}
		
	}

	void ReloadAndClip()
	{
		reloading = false;

		if (Pistol) 
		{
			countdown = pistolReload;
			bulletCount = pistolClip;
		}

		else if (SMG) 
		{
			countdown = SMGReload;
			bulletCount = SMGClip;
		
		}

		else if (Shotgun)
		{
			countdown = shotgunReload;
			bulletCount = shotgunClip;
		
		}
		
		
	}

	void GunShoot()
	{

		if(Input.GetMouseButton(0) && bulletCount > 0 )
		{


			if(!burst_timer){
				modelAnimator.SetBool ("Shooting", true);
				shadowAnimator.SetBool ("Shooting", true);
				burst_timer = true;
				Shoot ();
				//Spawn();

			}
		}


	}


	void RateOfFire()
	{

		if(burst_timer)
		{ 


			if (burst_countdown >= 0f) {
				burst_countdown -= Time.deltaTime;
			} 

			else 
			{
				

				if (Pistol) 
				{
					burst_countdown = pistolROF;

				}

				else if (Shotgun) 
				{
					burst_countdown = shotgunROF;

				}

				else if (SMG) 
				{
					burst_countdown = SMGROF;

				}

				modelAnimator.SetBool ("Shooting", false);
				shadowAnimator.SetBool ("Shooting", false);

				burst_timer = false;


			}
		}
		
	}



	void getDirection(){ 

		startPos = Camera.main.WorldToScreenPoint (transform.position);

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0f;

		shootDirection = mousePos - startPos;

		direc = Quaternion.LookRotation (transform.forward, shootDirection);
	}

	void Shoot(){



		getDirection ();
		Quaternion Ang;

		if (!Shotgun) 
		{

			Ang = direc;

			Instantiate (Bullet[0], bulletSpawner.transform.position, Ang);

			bulletCount--;
		}

		else
		{

			//Ang = direc * Quaternion.Euler(0f,0f,-3f);

			//Ang.z += 0.3f;
			//Instantiate (Bullet, bulletSpawner[0].transform.position, Quaternion.identity);
			//Instantiate (Bullet[1], bulletSpawner.transform.position, Ang);


			Ang = direc; 


			Instantiate (Bullet[1], bulletSpawner.transform.position, Ang);

			//Ang = direc * Quaternion.Euler(0f,0f,3f);

			//Instantiate (Bullet[1], bulletSpawner.transform.position, Ang);
			bulletCount--;

		}


	}

	void GunSwitch()
	{ //for playtesting only
	
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Pistol = true;
			Shotgun = false;
			SMG = false;

			
			bulletCount = pistolClip;
			reloadTime = pistolReload;
			burst_countdown =pistolROF;

			reloading = false;
			burst_timer = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			Pistol = false;
			Shotgun = true;
			SMG = false;

			
			bulletCount = shotgunClip;
			reloadTime = shotgunReload;
			burst_countdown = shotgunROF;

			reloading = false;
			burst_timer = false;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			Pistol = false;
			Shotgun = false;
			SMG = true;

			
			bulletCount = SMGClip;
			reloadTime = SMGReload;
			burst_countdown = SMGROF;

			reloading = false;
			burst_timer = false;
		}
	}
		

}
