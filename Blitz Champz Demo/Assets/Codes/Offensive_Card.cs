using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offensive_Card : Card {
	protected int value;
	protected bool kick = false;
	protected bool pass = false;
	protected bool run = false;
	void Start() {
	}
	protected override void Play() {
		//owner.field.;
		owner.update_score(value);
		AdvanceTurn();
	}
	protected void Remove() { //remove card from the field and discard it thus removing points from that player
		owner.update_score((-1) * value);
	}
	void Update () {
		
	}
}
