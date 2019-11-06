using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interception : Defensive_Card
{
    void Start()
    {
        
    }
    protected override void Play() {
		if (owner.table.last_card.pass) {
            owner.table.last_card.Remove();
        }
        AdvanceTurn();
	}
    private void OnMouseUpAsButton() {
		if (owner != null && owner.table.current_player == owner && owner.table.last_card != null) {
            if (owner.table.last_card.pass) {
                this.Play();
                this.Discard();
            } else {
                //display message that this is not a valid move
            }
		}
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/interception");
    }
    void Update()
    {
        
    }
}
