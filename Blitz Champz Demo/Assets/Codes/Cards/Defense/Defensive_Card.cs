using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensive_Card : Card {
	public bool kick = false;
	public bool pass = false;
	public bool run = false;

	// Use this for initialization
	void Start () {
		
	}
	protected override void Play() {
		AdvanceTurn();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
