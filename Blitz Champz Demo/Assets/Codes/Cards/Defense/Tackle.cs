using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tackle : Defensive_Card
{
    void Start()
    {
        run = true;
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/tackle");
    }
    void Update()
    {
        
    }
}
