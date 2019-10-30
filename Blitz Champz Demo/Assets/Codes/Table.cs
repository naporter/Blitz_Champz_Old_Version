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
    public Offensive_Card last_card;
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
        create_deck();
        order.AddLast(player1);
        order.AddLast(player2);
        current = order.First;
        current_player = player1;
        StartCoroutine(Wait_For_Deck());
    }

    IEnumerator Wait_For_Deck() {
        yield return new WaitUntil(() => draw_deck.draw_deck.Count == 100);
        Debug.Log("Deck == 100 " + draw_deck.draw_deck.Count);
        initial_deal();
    }
    private void create_deck() {
        Debug.Log("Deck start");
        GameObject deck = Resources.Load("Prefabs/deck") as GameObject;
        GameObject new_deck = Instantiate(deck, new Vector3(1.45f, 0f, 1f), transform.rotation);
        draw_deck = new_deck.GetComponent<Deck>();
        Debug.Log("Deck done");
    }
    public void initial_deal() {
        Debug.Log("Dealing start");
        Debug.Log(draw_deck.draw_deck.Count);
        current = current.List.Last;
        for (int i = 0; i < 5 * order.Count; i++) {
            AdvanceTurn();
        }
        AdvanceTurn();
        Debug.Log("Dealing done");
    }
    public void AdvanceTurn() {
        Update_Scores();
        current = current.Next ?? current.List.First;
        current_player = current.Value;
        current_player.draw();
    }
    public void Update_Scores() {
        p1.text = (player1.score).ToString();
        p2.text = (player2.score).ToString();
    }
    void Update() {
    }
}