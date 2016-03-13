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

	public enum eventtype
	{
		quest,
		oogabooga,
		upgrade,
		discovery,
		resources
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

	public class EventInfo
	{
		public eventtype _event;
		public int value;
		public string infoString;
		public string eventname;

		public void GenerateEventInfo (eventtype typ, int val, string inf, string nam)
		{
			_event = typ;
			value = val;
			infoString = inf;
			eventname = nam;
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
	public List<TileInfo> L_AllTilesInfo;
	public List<TileInfo> L_DiscoveredTiles;
	public List<EventInfo> L_AllEventInfo;
	public string[] _resources;
	public string[] _quests;
	public string[] _discoveries;
	public string[] _upgrades;


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
		ListOfEvents ();
	}


	void GenerateTileList ()
	{
		
		L_AllTilesInfo = new List<TileInfo> ();
		L_DiscoveredTiles = new List<TileInfo> ();

		for (int i = 0; i < 4000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.grass, Random.Range (1, 11), "Grassy Tile", grassSprite);
			L_AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 3000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.sand, Random.Range (1, 11), "Sandy Tile", sandSprite);
			L_AllTilesInfo.Add (newTile);
		}
		for (int i = 0; i < 3000; i++) {

			TileInfo newTile = new TileInfo ();
			newTile.GenerateTileInfo (tiletype.stone, Random.Range (1, 11), "Stony Tile", stoneSprite);
			L_AllTilesInfo.Add (newTile);
		}

		print (L_AllTilesInfo.Count);
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
		int tilessquared = (int)Mathf.Sqrt (L_AllTilesInfo.Count);
		print (tilessquared);

		for (int x = -(tilessquared / 2); x < (tilessquared / 2); x++) {
			for (int y = -(tilessquared / 2); y < (tilessquared / 2); y++) {

				if (x == 0 && y == 0) {
					print ("First tile is here");
				} else {
					GameObject go = Instantiate (tile, new Vector2 (x * 50, y * 50), Quaternion.identity) as GameObject;
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

	void ListOfEvents ()
	{
		L_AllEventInfo = new List<EventInfo> ();

		_resources = new string[10]; 
		_quests = new string[10];
		_discoveries = new string[4];
		_upgrades = new string[2];

		_resources [0] = "Clay";
		_resources [1] = "Stones";
		_resources [2] = "Water";
		_resources [3] = "Wood";
		_resources [4] = "Copper";
		_resources [5] = "Coal";
		_resources [6] = "Apples";
		_resources [7] = "Cotton";
		_resources [8] = "Iron";
		_resources [9] = "Gold";

		_quests [0] = "Old Bill would like his crap examined. Go talk to Bill.";
		_quests [1] = "Help me! I have diarrhea... Please open your ass! SWIPPY SWAP!";
		_quests [2] = "Use the pointy stick to engrave your daugthers face.";
		_quests [3] = "Bandits and snakes have taken your wife. You should trade them your daugther.";
		_quests [4] = "Somethings dripping out of the hole in the fleshy wall. Call Grandpa Bill.";
		_quests [5] = "Look out!";
		_quests [6] = "Snakes have decided to impregnate you. Make a basket.";
		_quests [7] = "Bandits have taken your daughter. Go to a desert.";
		_quests [8] = "Find the naked snake. His one eye should give him away.";
		_quests [9] = "Use gold with apples.";

		_discoveries [0] = "Your wife!";
		_discoveries [1] = "A trading post!";
		_discoveries [2] = "Shoes!";
		_discoveries [3] = "A source of freshwater!";

		_upgrades [0] = "Speed";
		_upgrades [1] = "Gathering capacity";


		for (int i = 0; i < 10; i++) {
			EventInfo newEvent = new EventInfo ();
			int ran = Random.Range (0, _resources.Length);
			newEvent.GenerateEventInfo (eventtype.resources, ran, "You found some resources: " + ran + _resources [ran], "" + _resources [ran]);
			L_AllEventInfo.Add (newEvent);
		}
		for (int i = 0; i < 10; i++) {
			EventInfo newEvent = new EventInfo ();
			int ran = Random.Range (0, 11);
			newEvent.GenerateEventInfo (eventtype.oogabooga, ran, "You have encountered " + ran + " Oogaboogas!", "Oogaboogas");
			L_AllEventInfo.Add (newEvent);
		}
		for (int i = 0; i < 10; i++) {
			EventInfo newEvent = new EventInfo ();
			int ran = Random.Range (0, _quests.Length);
			newEvent.GenerateEventInfo (eventtype.quest, ran, "A new quest! " + _quests [ran], "Quest nr. " + ran);
			L_AllEventInfo.Add (newEvent);
		}
		for (int i = 0; i < 10; i++) {
			EventInfo newEvent = new EventInfo ();
			int ran = Random.Range (0, _discoveries.Length);
			newEvent.GenerateEventInfo (eventtype.discovery, ran, "A new discovery! " + _discoveries [ran], "Discovery nr. " + ran);
			L_AllEventInfo.Add (newEvent);
		}
		for (int i = 0; i < 10; i++) {
			EventInfo newEvent = new EventInfo ();
			int ran = Random.Range (0, _upgrades.Length);
			newEvent.GenerateEventInfo (eventtype.upgrade, ran, "You can upgrade your: " + _discoveries [ran], "Discovery nr. " + ran);
			L_AllEventInfo.Add (newEvent);
		}
	}

}
