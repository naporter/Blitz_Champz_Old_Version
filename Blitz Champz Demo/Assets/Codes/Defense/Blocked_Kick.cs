using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocked_Kick : Defensive_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/blocked_kick");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
