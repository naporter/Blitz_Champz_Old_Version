using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_Yard_Run : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/5_yard_run");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
