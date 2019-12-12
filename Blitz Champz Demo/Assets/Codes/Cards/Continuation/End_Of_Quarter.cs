using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
public class End_Of_Quarter : Continuation_Card
{
    public string spriteName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [PunRPC]
    protected override void Play() {
        owner.table.Reverse();
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
