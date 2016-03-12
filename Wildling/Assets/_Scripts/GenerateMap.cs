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
	private SpriteRenderer sprRend;
	private Sprite grassSprite;
	private Sprite sandSprite;
	private Sprite stoneSprite;


	// All ints

	// All lists
	public List<TileInfo> AllTilesInfo;
	public List<TileInfo> DiscoveredTiles;



	// Use this for initialization
	void Start ()
	{
		tile = Resources.Load ("Prefabs/Tile") as GameObject;
		grassSprite = Resources.Load<Sprite> ("Materials/Sprites/Grass");
		sandSprite = Resources.Load<Sprite> ("Materials/Sprites/Sand");
		stoneSprite = Resources.Load<Sprite> ("Materials/Sprites/Stone");

		print (grassSprite.name);

		GenerateTileList ();
		GenerateFirstTiles (tiletype.grass, 1, "Grassy Tile", grassSprite, 0, 0, true);
		GenerateAllBlankTiles ();
		//GenerateAllTiles ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void GenerateTileList ()
	{
		
		AllTilesInfo = new List<TileInfo> ();
		DiscoveredTiles = new List<TileInfo> ();

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

	public void GenerateFirstTiles (tiletype typ, int val, string nam, Sprite spr, int x, int y, bool trig)
	{
		GameObject go = Instantiate (tile, Vector3.zero, Quaternion.identity) as GameObject;
		go.GetComponent<TileScript> ()._tiletype = typ;
		go.GetComponent<TileScript> ().value = val;
		go.GetComponent<TileScript> ().tilename = nam;
		go.GetComponent<SpriteRenderer> ().sprite = spr;
		go.GetComponent<SpriteRenderer> ().color = Color.white;
		go.transform.position = new Vector2 (x, y);
		go.GetComponent<TileScript> ().isTriggered = trig;


	}

	void GenerateAllBlankTiles ()
	{
		int tilessquared = (int)Mathf.Sqrt (AllTilesInfo.Count);
		print (tilessquared);

		for (int x = -(tilessquared / 2); x < (tilessquared / 2); x++) {
			for (int y = -(tilessquared / 2); y < (tilessquared / 2); y++) {

				if (x == 0 && y == 0) {
					print ("First tile is here");
				} else {
					GameObject go = Instantiate (tile, new Vector2 (x * 10, y * 10), Quaternion.identity) as GameObject;
					go.GetComponent<TileScript> ().isTriggered = false;
				}
			}
		}
	}

	public void GenerateOneTileInfo (GameObject go, tiletype typ, int val, string nam, Sprite spr, bool trig)
	{
		go.GetComponent<TileScript> ()._tiletype = typ;
		go.GetComponent<TileScript> ().value = val;
		go.GetComponent<TileScript> ().tilename = nam;
		go.GetComponent<SpriteRenderer> ().sprite = spr;
		go.GetComponent<SpriteRenderer> ().color = Color.white;
		go.GetComponent<TileScript> ().isTriggered = trig;
	}

	/*void GenerateAllTiles ()
	{


		TileInfo tileinfo = new TileInfo ();

		int ran = Random.Range (0, AllTilesInfo.Count);
		tileinfo = AllTilesInfo [ran];
		GenerateFirstTiles (tileinfo.type, tileinfo.value, tileinfo.tilename, tileinfo.tileSprite, x * 10, y * 10, false);
		AllTilesInfo.Remove (AllTilesInfo [ran]);

			

	}*/
}
