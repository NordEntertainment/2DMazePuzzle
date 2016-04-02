using UnityEngine;
using System.Collections;

public class HomeTile : MonoBehaviour
{



	// All Gameobjects
	private GameObject hometile;

	// All Sprites
	private SpriteRenderer sprRend;
	private Sprite grassSprite;
	private Sprite sandSprite;
	private Sprite stoneSprite;

	// Use this for initialization
	void Start ()
	{
		
		hometile = Resources.Load ("Prefabs/Tile") as GameObject;

		GameObject go = Instantiate (hometile, new Vector2 (0, 0), Quaternion.identity) as GameObject;

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
