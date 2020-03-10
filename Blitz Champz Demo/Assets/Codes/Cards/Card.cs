using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour {
	public Player owner;
	protected bool valid = true;
	protected bool win_played = false;
	public void SetOwner(Player own) {
		this.owner = own;
		if (owner.up) {
			gameObject.transform.rotation = Quaternion.Euler(0,0,0f);
		}
	}
	public virtual bool CheckValid() {
		return valid;
	}
	void Start () {
	}
	public void Discard () {
		if (this.owner != null) {
			for (int i = 0; i < owner.hand.Count; i++) {
				owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
			}
			owner.table.last_card = null;
			gameObject.GetComponent<Transform>().position = new Vector3(-1.45f, 0f, 0f);
			gameObject.transform.rotation = Quaternion.Euler(0,0,0f);
			owner.table.Discard(gameObject);
			owner.Remove(gameObject);
			this.owner = null;
			Destroy(GetComponent<BoxCollider>());
			Show();
		}
	}
	public void Hide() {
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/back");
	}
	public virtual void Show() {
	}
	public void AdvanceTurn() {
		owner.table.AdvanceTurn();
	}
	private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner) {
			this.Play();
			this.Discard();
		}
	}
	void OnMouseEnter() {
		if (owner != null && owner == owner.table.current_player) {
			if (owner.hand.Contains(gameObject)) {
				gameObject.transform.position += Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
				gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
				for (int i = 0; i < owner.hand.Count; i++) {
					if (owner.hand[i] != gameObject) {
						if (owner.hand[i].GetComponent<Card>().win_played) {
							gameObject.GetComponent<SpriteRenderer>().color = Color.white;
						} else {
						owner.hand[i].GetComponent<SpriteRenderer>().color = Color.gray;
						}
					}
				}
			} else {
				foreach(Player a in owner.table.order) {
					if (owner != a && a.field.Contains(gameObject)) {
						foreach(Player b in owner.table.order) {
							if (b != a) {
								for (int i = 0; i < b.field.Count; i++) {
									if (b.field[i] != gameObject) {
										b.field[i].GetComponent<SpriteRenderer>().color = Color.gray;
									}
								}
							}
						}
						gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
						for (int i = 0; i < a.field.Count; i++) {
							if (a.field[i] != gameObject) {
								a.field[i].GetComponent<SpriteRenderer>().color = Color.gray;
							}
						}
					}
				}
			}
		}
	}
	void OnMouseExit() {
		if (owner != null && owner == owner.table.current_player) {
			if (owner.hand.Contains(gameObject)) {
				gameObject.transform.position -= Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
				gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
				if (!win_played){
					for (int i = 0; i < owner.hand.Count; i++) {
						owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
					}
				} else {
					gameObject.GetComponent<SpriteRenderer>().color = Color.white;
				}
			} else {
				foreach(Player a in owner.table.order) {
					if (owner != a && a.field.Contains(gameObject)) {
						foreach(Player b in owner.table.order) {
							if (b != a) {
								for (int i = 0; i < b.field.Count; i++) {
									if (b.field[i] != gameObject) {
										b.field[i].GetComponent<SpriteRenderer>().color = Color.white;
									}
								}
							}
						}
						gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
						for (int i = 0; i < a.field.Count; i++) {
							a.field[i].GetComponent<SpriteRenderer>().color = Color.white;
						}
					}
				}
			}
		}
	}
	protected virtual void Play () {
	}
	void Update () {
		
	}
}