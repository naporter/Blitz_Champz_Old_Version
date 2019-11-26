using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class Pass_Completion : Continuation_Card
{
    void Start() {
    }
    [PunRPC]
    protected override void Play() {
        owner.Draw();
        AdvanceTurn();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/pass_completion");
    }
    void Update() {
        
    }
}