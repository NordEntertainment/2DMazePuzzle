using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{


	public float moveSpeed;
	public float rotationSpeed;
	public Vector2 Velocity;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CharMove ();
	}

	void CharMove ()
	{

		rb2d.MovePosition (rb2d.position + Velocity * Time.deltaTime);

		if (Input.GetKey ("up") || Input.GetKey ("w")) {

			rb2d.AddForce (Vector2.up * moveSpeed);
			rb2d.MoveRotation (angle: 0);


		}
		if (Input.GetKey ("down") || Input.GetKey ("s")) {

			rb2d.AddForce (Vector2.down * moveSpeed);
			rb2d.MoveRotation (angle: 180);


		}
		if (Input.GetKey ("right") || Input.GetKey ("d")) {

			rb2d.AddForce (Vector2.right * moveSpeed);
			rb2d.MoveRotation (angle: 270);
	

		}
		if (Input.GetKey ("left") || Input.GetKey ("a")) {

			rb2d.AddForce (Vector2.left * moveSpeed);
			rb2d.MoveRotation (angle: 90);
		

		}
	}
}
