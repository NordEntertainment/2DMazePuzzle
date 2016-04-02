using UnityEngine;
using System.Collections;

public class AutoCamSize : MonoBehaviour
{




	// Use this for initialization
	void Start ()
	{
		autoCamWidth ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void autoCamWidth ()
	{
		SpriteRenderer spr = (SpriteRenderer)GetComponent ("Renderer");
		if (spr == null)
			return;

		spr.sprite.texture.filterMode = FilterMode.Point;

		double width = spr.sprite.bounds.size.x;
		print ("width = " + width);
		double worldScreenHeight = Camera.main.orthographicSize * 2;
		double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		transform.localScale = new Vector2 (1, 1) * (float)(worldScreenWidth / width);
	}
}
