using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Of_Quarter : Continuation_Card
{
    public string spriteName;
    //Get the AudioSource for each Offensive card
	private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected override void Play() {
        owner.table.Reverse();
        //When the card is played, play the sound attached to it
		source = GetComponent<AudioSource>();
		source.Play();
        AdvanceTurn();
    }
	public override void Show() {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(spriteName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
