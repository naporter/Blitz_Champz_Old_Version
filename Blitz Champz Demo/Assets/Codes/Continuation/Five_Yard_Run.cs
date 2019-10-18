using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_Yard_Run : Continuation_Card
{
    void Start() {
    }
    protected override void Play() {
        owner.draw();
        owner.drew = true;
    }
    private void OnMouseUpAsButton() {
		if (owner.drew == false){
            if (owner != null && owner.table.current_player == owner) {
                this.Play();
                this.Discard();
            }
        }
	}
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/5_yard_run");
    }
    void Update() {       
    }
}