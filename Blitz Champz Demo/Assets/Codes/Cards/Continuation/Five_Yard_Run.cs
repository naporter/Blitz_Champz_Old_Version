using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class Five_Yard_Run : Continuation_Card
{
    void Start() {
    }
    [PunRPC]
    protected override void Play() {
        AdvanceTurn();
        owner.Draw();
        owner.StackCards();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/5_yard_run");
    }
    void Update() {       
    }
}