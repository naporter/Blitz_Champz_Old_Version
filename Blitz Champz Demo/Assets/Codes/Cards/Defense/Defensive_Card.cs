using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defensive_Card : Card {
	protected bool kick = false;
	protected bool pass = false;
	protected bool run = false;

	void Start () {
		
	}
	public bool GetKick() {
		return kick;
	}
	public bool GetPass() {
		return pass;
	}
	public bool GetRun() {
		return run;
	}
	protected override void Play() {
		owner.table.last_card.Remove();
		AdvanceTurn();
	}
	private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner && owner.table.last_card != null) {
            if (CheckValid()) {
				this.Play();
                this.Discard();
            } else {
                //display a message that this is not a valid move
            }
		}
	}
	public override bool CheckValid() {
		if (owner.table.last_card.GetPass() == true && pass == true) {
			valid = true;
			return true;
		} else if (owner.table.last_card.GetRun() == true && run == true) {
			valid = true;
			return true;
		} else if (owner.table.last_card.GetKick() == true && kick == true) {
			valid = true;
			return true;
		} else {
			valid = true;
			return false;
		}
	}
	void Update () {
		
	}
}
