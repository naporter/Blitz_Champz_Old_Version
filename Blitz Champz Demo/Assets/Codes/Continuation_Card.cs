using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuation_Card : Card {

	protected override void Play() {
	}
	void Start () {
		
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/first_down");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
