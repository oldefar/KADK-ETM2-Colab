using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

    public Sprite newSprite;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.GetComponent<PlayerTouch>().touched == true)
        {
            transform.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
	}
}
