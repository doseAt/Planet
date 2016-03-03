using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	Rigidbody2D rigidbody;

	void Awake()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		Invoke ("Go",0.5f);
	}

	public void Go()
	{
		Vector2 movement = new Vector2 (-transform.position.x, -transform.position.y);
		movement.Normalize ();
		rigidbody.velocity = movement * speed;

	}
}
