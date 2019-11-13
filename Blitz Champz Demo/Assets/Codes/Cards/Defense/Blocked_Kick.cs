using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocked_Kick : Defensive_Card
{
    void Start()
    {
        kick = true;
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blocked_kick");
    }
    void Update()
    {
        
    }
}
