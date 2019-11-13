using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitz : Continuation_Card
{
    private bool played = false;
    void Start()
    {
        
    }
    protected override void Play() {
        StartCoroutine(SelectCard());
    }
    IEnumerator SelectCard() {
        owner.table.SetReady(false);
        foreach (GameObject card in owner.hand) {
                    card.GetComponent<BoxCollider>().enabled = false;
        }
        foreach (Player a in owner.table.order) {
            if (owner != a) {
                foreach (GameObject card in a.field) {
                    card.GetComponent<Card>().owner = owner;
                    card.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
        played = true; //this is used to disable the OnMouseExit() method so that it doesn't lighten the cards
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Show();
        gameObject.transform.position += Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
        gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
        for (int i = 0; i < owner.hand.Count; i++) {
            if (owner.hand[i] != gameObject) {
                owner.hand[i].GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }
        yield return new WaitUntil(() => owner.table.current_player != owner);
        foreach (Player a in owner.table.order) {
            GameObject stolenCard = null;
            if (owner != a) {
                foreach (GameObject card in a.field) {
                    if (owner.field.Contains(card)) {
                        stolenCard = card;
                    } else {
                        card.GetComponent<Card>().owner = a;
                    }
                    card.GetComponent<BoxCollider>().enabled = false;
                    card.GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (stolenCard) {
                    a.field.Remove(stolenCard);
                    a.order_field();
                }
            }
        }
        for (int i = 0; i < owner.hand.Count; i++) {
			owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
		}
        foreach (GameObject card in owner.hand) {
            card.GetComponent<BoxCollider>().enabled = true;
        }
        owner.order_field();
        owner.table.SetReady(true);
        this.Discard();
    }
    private void OnMouseUpAsButton() {
		bool canPlay = false;
        foreach (Player a in owner.table.order) {
            if (a != owner) {
                if (a.field.Count > 0) {
                    canPlay = true;
                }
            }
        }
        if (owner != null && owner.table.current_player == owner) {
			if (canPlay) {
                StartCoroutine(SelectCard());
            }
            else {
                Debug.Log("Not a valid move!");
            }
		}
	}
    void OnMouseExit() {
		if (owner != null && owner == owner.table.current_player && !played) {
			if (owner.hand.Contains(gameObject)) {
				gameObject.transform.position -= Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
				gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
				for (int i = 0; i < owner.hand.Count; i++) {
					owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
				}
			} else {
				foreach(Player a in owner.table.order) {
					if (owner != a && a.field.Contains(gameObject)) {
						gameObject.GetComponent<SpriteRenderer>().sortingOrder -=20;
						for (int i = 0; i < a.field.Count; i++) {
							a.field[i].GetComponent<SpriteRenderer>().color = Color.white;
						}
					}
				}
			}
		}
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blitz");
    }
    public new void Discard () {
		if (this.owner != null) {
			for (int i = 0; i < owner.hand.Count; i++) {
				owner.hand[i].GetComponent<SpriteRenderer>().color = Color.white;
			}
			gameObject.GetComponent<Transform>().position = new Vector3(-1.45f, 0f, 0f);
			gameObject.transform.rotation = Quaternion.Euler(0,0,0f);
			owner.table.Discard(gameObject);
			owner.remove(gameObject);
			this.owner = null;
			Destroy(GetComponent<BoxCollider>());
			Show();
		}
	}
    void Update()
    {
        
    }
}
