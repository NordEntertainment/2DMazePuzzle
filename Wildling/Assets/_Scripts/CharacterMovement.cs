using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{


	public float moveSpeed;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.rotation.Set (0, 0, 0, 0);
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.rotation.Set (0, 0, 0, 0);
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.rotation.Set (0, 0, 0, 0);
			transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.rotation.Set (0, 0, 0, 0);
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
		}

	}
}
