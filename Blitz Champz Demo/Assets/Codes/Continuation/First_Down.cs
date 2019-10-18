using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Down : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected override void Play() {
        owner.draw();
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
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/first_down");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
