using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interception : Defensive_Card
{
    void Start()
    {
        pass = true;
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/interception");
    }
    void Update()
    {
        
    }
}
