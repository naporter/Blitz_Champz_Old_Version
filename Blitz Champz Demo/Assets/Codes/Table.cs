using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public Deck draw_deck;
    public List<GameObject> discard;
    public void Discard(GameObject card) {
        card.GetComponent<SpriteRenderer>().sortingOrder = discard.Count;
        discard.Add(card);

    }
    public Player player1;
    public Player player2;
    public Text p1;
    public Text p2;
    public Player current_player;
    // Start is called before the first frame update
    public LinkedList<Player> order;
    void Start()
    {
        Player[] players = {player1, player2};
        current_player = player1;
        for (int i = 0; i < 5; i++) {
            current_player = player2;
            player2.draw(draw_deck);
            current_player = player1;
            player1.draw(draw_deck);
        }
        player1.draw(draw_deck);
    }
    public void AdvanceTurn(Player player) {
        Update_Scores();
        if (player == player1) {
            current_player = player2;
            player2.draw(draw_deck);
        } else {
            current_player = player1;
            player1.draw(draw_deck);
        }
    }
    public void Update_Scores() {
        p1.text = (player1.score).ToString();
        p2.text = (player2.score).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
