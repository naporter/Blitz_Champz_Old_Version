using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class Offensive_Card : Card {
	protected int value;
	protected bool kick = false;
	protected bool pass = false;
	protected bool run = false;
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
	[PunRPC]
	protected override void Play() {
		owner.field.Add(gameObject);
		owner.hand.Remove(gameObject);
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
		this.photonView.RPC("Discard", RpcTarget.All);
	}
	private void OnMouseUpAsButton() {
		if ((gameObject.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer && owner != null && owner.table.current_player == owner) || (owner == owner.table.current_player && !owner.table.ready && owner.gameObject.GetComponent<PhotonView>().Owner == PhotonNetwork.LocalPlayer)) { //| (owner == owner.table.current_player) second case is for when blitz is played

			this.photonView.RPC("Play", RpcTarget.All);
		}
	}
	void Update () {
	}
}