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

		public void GenerateTileInfo (tiletype til, int val, string nam)
		{
			type = til;
			value = val;
			tilename = nam;
		}

	}


	// All Gameobjects
	public GameObject tile;

	// All ints

	// All lists
	private List<TileInfo> AllTilesInfo;



	// Use this for initialization
	void Start ()
	{
		GenerateTileList ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void GenerateTileList ()
	{
		
		AllTilesInfo = new List<TileInfo> ();

		for (int i = 0; i < 100; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.grass, Random.Range (1, 11), "Grassy Tile");
			AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 100; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.sand, Random.Range (1, 11), "Sandy Tile");
			AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 100; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.stone, Random.Range (1, 11), "Stony Tile");
			AllTilesInfo.Add (newTile);
		}

		print (AllTilesInfo.Count);
	}


}
