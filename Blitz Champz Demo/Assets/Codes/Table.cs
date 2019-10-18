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
    public Card last_card;
    public Player pov_player;
    public Player player1;
    public Player player2;
    public Text p1;
    public Text p2;
    public Player current_player;
    LinkedListNode<Player> current;
    // Start is called before the first frame update
    public LinkedList<Player> order = new LinkedList<Player>();
    void Start() {
        order.AddLast(player1);
        order.AddLast(player2);
        current = order.First;
        current_player = player1;
        for (int i = 0; i < 5; i++) {
            current_player = player2;
            player2.draw();
            current_player = player1;
            player1.draw();
        }
        player1.draw();
    }
    public void AdvanceTurn(Player player) {
        Update_Scores();
        current = current.Next ?? current.List.First;
        current_player = current.Value;
        current_player.draw();
        current_player.drew = false;

        /*
        if (player == player1) {
            current_player = player2;
            player2.draw();
            player2.drew = false;
        } else {
            current_player = player1;
            player1.draw();
            player1.drew = false;
        }
        */
    }
    public void Update_Scores() {
        p1.text = (player1.score).ToString();
        p2.text = (player2.score).ToString();
    }
    void Update() {
    }
}