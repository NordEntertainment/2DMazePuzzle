using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
	public GenerateMap genMap;

	public float moveSpeed;
	public float rotationSpeed;
	public Vector2 Velocity;

	private Rigidbody2D rb2d;




	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		genMap = GameObject.Find ("_SCRIPTS").GetComponent<GenerateMap> ();
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

	void OnTriggerEnter2D (Collider2D col)
	{
		SpawnTileAndTileInfo (col);
		RollForTileEvent ();
	
	}

	void SpawnTileAndTileInfo (Collider2D col)
	{
		if (!col.gameObject.GetComponent<TileScript> ().isTriggered) {
			print ("entered");

			int ran;
			ran = Random.Range (0, genMap.L_AllTilesInfo.Count);

			GenerateMap.TileInfo newtile = new GenerateMap.TileInfo ();
			newtile = genMap.L_AllTilesInfo [ran];
			genMap.GenerateOneTileInfo (col.gameObject, newtile.type, newtile.value, newtile.tilename, newtile.tileSprite, true);
			genMap.L_AllTilesInfo.Remove (genMap.L_AllTilesInfo [ran]);

		}
	}

	void RollForTileEvent ()
	{
		int ran = Random.Range (1, 3);

		if (ran == 1) {
			print ("Nothing happend.");
		}
		if (ran == 2) {
			int rand = Random.Range (0, genMap.L_AllEventInfo.Count);
			print ("This happend: " + genMap.L_AllEventInfo [rand].eventname + " - "
			+ genMap.L_AllEventInfo [rand].infoString);
		}
	}
}
