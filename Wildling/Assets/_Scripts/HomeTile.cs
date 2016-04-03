using UnityEngine;
using System.Collections;

public class HomeTile : MonoBehaviour
{



	// All Gameobjects
	private GameObject hometile;

	// All Sprites
	private SpriteRenderer sprRend;
	private Sprite homeTileSprite;


	// Use this for initialization
	void Start ()
	{
		
		hometile = Resources.Load ("Prefabs/HomeTile") as GameObject;
		homeTileSprite = Resources.Load<Sprite> ("Materials/Sprites/Backgrounds/Town");



		GameObject go = Instantiate (hometile, new Vector2 (0, 0), Quaternion.identity) as GameObject;



	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
