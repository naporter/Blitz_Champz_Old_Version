using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocked_Kick : Defensive_Card
{
    void Start()
    {
        kick = true;
    }
    protected override void Play() {
		if (owner.table.last_card.kick) {
            owner.table.last_card.Remove();
        }
        AdvanceTurn();
	}
    private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner && owner.table.last_card != null) {
            if (owner.table.last_card.kick) {
                this.Play();
                this.Discard();
            } else {
                //display a message that this is not a valid move
            }
		}
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blocked_kick");
    }
    void Update()
    {
        
    }
}
