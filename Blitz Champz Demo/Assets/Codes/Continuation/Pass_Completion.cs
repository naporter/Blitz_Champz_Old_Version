using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_Completion : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/pass_completion");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
