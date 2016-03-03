using UnityEngine;
using System.Collections;

public class AreaBomb : MonoBehaviour {

	CircleCollider2D circleCollider;
	Rigidbody2D rigidbody;
	Transform explosionCircle;
	bool explosion;
	SpriteRenderer sprite;

	void Awake()
	{
		circleCollider = gameObject.GetComponent<CircleCollider2D>();
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		explosion = false;
		explosionCircle = transform.GetChild(0).GetComponent<Transform>();
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(explosion)
		{
			rigidbody.velocity = Vector2.zero;
			SpreadCircle();
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "AreaBombTrigger")
		{
			//particles Instantiate()
			explosion = true;
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag == "Enemy" && explosion)
		{
			Destroy(other.gameObject);

		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "AreaBombTrigger")
		{
			//particles Instantiate()
			explosion = true;
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag == "Enemy" && explosion)
		{
			Destroy(other.gameObject);

		}
	}

	void SpreadCircle()
	{
		if(explosionCircle.localScale.x >= 4.5f)
		{
			Destroy(gameObject);
		}
		else
		{
			sprite.enabled = false;
			explosionCircle.localScale = new Vector3(explosionCircle.localScale.x + 0.05f, explosionCircle.localScale.y + 0.05f, 1);
		}
	}

	public void SetTarget(float x, float y)
	{
		rigidbody.velocity = new Vector2(x, y);
	}


}