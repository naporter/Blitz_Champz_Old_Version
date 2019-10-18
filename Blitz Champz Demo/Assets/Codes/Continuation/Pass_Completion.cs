using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_Completion : Continuation_Card
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
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/pass_completion");
    }
    void Update() {
        
    }
}