using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blitz : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected override void Play() {
        StartCoroutine(SelectCard());
    }
    IEnumerator SelectCard() {
        owner.table.blitz = true;
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
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Show();
        gameObject.transform.position += Vector3.Scale(transform.up, new Vector3(0f, 0.5f, 0f));
        gameObject.GetComponent<SpriteRenderer>().sortingOrder +=20;
        /*  This doesn't work, the OnMouseExit() function switches them all back to white immediately. Need to figure out how to get around that
        for (int i = 0; i < owner.hand.Count; i++) {
            if (owner.hand[i] != gameObject) {
                owner.hand[i].GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }
        */
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
        this.Discard();
    }
    private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner) {
			StartCoroutine(SelectCard());
		}
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blitz");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
