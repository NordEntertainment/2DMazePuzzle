using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour
{

	public enum tiletype
	{
		grass,
		sand,
		stone
	}

	public class TileInfo
	{

		public tiletype type;
		public int value;
		public string tilename;
		public Sprite tileSprite;

		public void GenerateTileInfo (tiletype til, int val, string nam, Sprite tiS)
		{
			type = til;
			value = val;
			tilename = nam;
			tileSprite = tiS;
		}

	}


	// All Gameobjects
	private GameObject tile;

	// All Sprites
	private Sprite grassSprite;
	private Sprite sandSprite;
	private Sprite stoneSprite;


	// All ints

	// All lists
	private List<TileInfo> AllTilesInfo;



	// Use this for initialization
	void Start ()
	{
		tile = Resources.Load ("Prefabs/Tile") as GameObject;
		grassSprite = Resources.Load<Sprite> ("Materials/Sprites/Grass");
		sandSprite = Resources.Load<Sprite> ("Materials/Sprites/Sand");
		stoneSprite = Resources.Load<Sprite> ("Materials/Sprites/Stone");

		print (grassSprite.name);

		GenerateTileList ();
		GenerateAllTiles ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void GenerateTileList ()
	{
		
		AllTilesInfo = new List<TileInfo> ();

		for (int i = 0; i < 4000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.grass, Random.Range (1, 11), "Grassy Tile", grassSprite);
			AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 3000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.sand, Random.Range (1, 11), "Sandy Tile", sandSprite);
			AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 3000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.stone, Random.Range (1, 11), "Stony Tile", stoneSprite);
			AllTilesInfo.Add (newTile);
		}

		print (AllTilesInfo.Count);
	}

	void GenerateOneTile (tiletype typ, int val, string nam, Sprite spr, int x, int y)
	{
		GameObject go = Instantiate (tile, Vector3.zero, Quaternion.identity) as GameObject;
		go.GetComponent<TileScript> ()._tiletype = typ;
		go.GetComponent<TileScript> ().value = val;
		go.GetComponent<TileScript> ().tilename = nam;
		go.GetComponent<SpriteRenderer> ().sprite = spr;
		go.transform.position = new Vector2 (x, y);
	}

	void GenerateAllTiles ()
	{
		int tilessquared = (int)Mathf.Sqrt (AllTilesInfo.Count);
		print (tilessquared);

		TileInfo tileinfo = new TileInfo ();


		for (int x = 0; x < tilessquared; x++) {
			for (int y = 0; y < tilessquared; y++) {

				int ran = Random.Range (0, AllTilesInfo.Count);
				tileinfo = AllTilesInfo [ran];
				GenerateOneTile (tileinfo.type, tileinfo.value, tileinfo.tilename, tileinfo.tileSprite, x * 5, y * 5);
				AllTilesInfo.Remove (AllTilesInfo [ran]);

			}
		}
	}
}
