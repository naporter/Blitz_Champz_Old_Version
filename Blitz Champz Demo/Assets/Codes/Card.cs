using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card : MonoBehaviour {
	public Player owner;
	public void SetOwner(Player own) {
		this.owner = own;
		gameObject.GetComponentInChildren<TextMeshPro>().SetText(owner.name + "\nHand");
	}
	void Start () {
	}

	public void Discard () {
		if (this.owner != null) {
			gameObject.GetComponent<Transform>().position = new Vector3(-1f, 0f, 0f);
			gameObject.GetComponentInChildren<TextMeshPro>().SetText("None" + "\nDiscarded");
			owner.table.Discard(gameObject);
			owner.remove(gameObject);
			owner.order_cards();
			this.owner = null;
			
		}
	}
	private void OnMouseUpAsButton() {
		if (owner.table.current_player == owner) {
			this.Play();
			owner.table.AdvanceTurn(owner);
			this.Discard();
		}
	}
	protected virtual void Play () {
	}
	// Update is called once per frame
	void Update () {
		
	}
}