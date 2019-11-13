using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : Defensive_Card
{
    void Start()
    {
        run = true;
    }
    protected override void Play() {
		if (owner.table.last_card.run) {
            owner.table.last_card.Remove();
        }
        AdvanceTurn();
	}
    private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner && owner.table.last_card != null) {
            if (owner.table.last_card.run) {
                this.Play();
                this.Discard();
            } else {
                //display message that this is not a valid move
            }
		}
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/tackle");
    }
    void Update()
    {
        
    }
}
