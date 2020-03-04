using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five_Yard_Run : Continuation_Card
{
    //Get the AudioSource for each Offensive card
	private AudioSource source;
    void Start() {
    }
    protected override void Play() {
        owner.Draw();
        //When the card is played, play the sound attached to it
		source = GetComponent<AudioSource>();
		source.Play();
        AdvanceTurn();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/5_yard_run");
    }
    void Update() {       
    }
}