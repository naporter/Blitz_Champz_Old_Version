using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumble : Continuation_Card
{
    void Start()
    {
        
    }
    protected override void Play() {
        owner.table.Skip();
        AdvanceTurn();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/fumble");
    }
    void Update()
    {
        
    }
}
