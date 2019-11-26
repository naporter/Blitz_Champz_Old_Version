using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class First_Down : Continuation_Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [PunRPC]
    protected override void Play() {
        owner.Draw();
        owner.Draw();
        AdvanceTurn();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/first_down");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
