using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offensive_Card : Card {
	protected int value;
	protected bool kick = false;
	protected bool pass = false;
	protected bool run = false;
	//Get the AudioSource for each Offensive card
	private AudioSource source;
	void Start() {
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
		owner.field.Add(gameObject);
		owner.hand.Remove(gameObject);
		//When the card is played, play the sound attached to it
		//Currently, this sound plays again when it is stolen with a Blitz card
		source = GetComponent<AudioSource>();
		source.Play();
		owner.table.last_card = this;
		for (int i = 0; i < owner.hand.Count; i++) {
			owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
		gameObject.GetComponent<BoxCollider>().enabled = false;
		Show();
		AdvanceTurn();
	}
	public int GetValue() {
		return value;
	}
	public void Remove() { //remove card from the field and discard it thus removing points from that player
		owner.UpdateScore();
		Discard();
	}
	private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner) {
			this.Play();
		}
	}
	void Update () {
	}
}