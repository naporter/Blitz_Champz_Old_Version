using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
	public int score;
	public List<GameObject> hand;
	public Table table;
	public bool right = false;
	List<GameObject> field;
	// Use this for initialization
	void Start () {
		score = 0;
		if (this.transform.position.x > 0) {right = true;}
	}
	public void update_score(int change) {
		score += change;
	}
	public void draw(Deck draw_deck) {
		if (draw_deck.draw_deck.Count > 0 && table.current_player == this) {
			GameObject new_card = draw_deck.Draw(this);
			new_card.GetComponent<Card>().SetOwner(this);
			hand.Add(new_card);
			order_cards();
		}
	}
	public void remove(GameObject card) {
		hand.Remove(card);
	}
	public void order_cards() {
		if (right) {
			
			for (int i = 0; i < hand.Count; i++) {
				Vector3 adjustment = new Vector3(-1 * 0.5f * i, 0.0f, 0.0f);
				hand[i].GetComponent<SpriteRenderer>().sortingOrder = 2 * i;
				hand[i].GetComponentInChildren<TextMeshPro>().sortingOrder = 2 * i + 1;
				hand[i].GetComponent<Transform>().position = gameObject.transform.position + adjustment + new Vector3(0f, 0f, 2 * (hand.Count - i));
				if (this == table.pov_player) {
					hand[i].GetComponent<Card>().Show();
				}
			}
		}
		else {
			
			for (int i = 0; i < hand.Count; i++) {
				Vector3 adjustment = new Vector3(0.5f * i, 0.0f, 0.0f);
				hand[i].GetComponent<SpriteRenderer>().sortingOrder = 2 * (hand.Count - i);
				hand[i].GetComponentInChildren<TextMeshPro>().sortingOrder = 2 * (hand.Count - i) + 1;
				hand[i].GetComponent<Transform>().position = gameObject.transform.position + adjustment + new Vector3(0f, 0f, 2 * i);
				if (this == table.pov_player) {
					hand[i].GetComponent<Card>().Show();
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}