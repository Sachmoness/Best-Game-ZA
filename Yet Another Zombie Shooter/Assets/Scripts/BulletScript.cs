using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int Damage;
	public float Speed;

	private Rigidbody _self;


	// Use this for initialization
	void Start () {

		//startPos = transform.position;

		_self = gameObject.GetComponent<Rigidbody> ();
		_self.velocity = new Vector3 (0,0,0);

		_self.AddForce (transform.up*Speed, ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision obj){

		if (obj.gameObject.tag == "Bullet") {
			Physics.IgnoreCollision (gameObject.GetComponent<Collider> (), obj.gameObject.GetComponent<Collider> ());
		} else {

			Destroy (gameObject);
		}
	}

}
