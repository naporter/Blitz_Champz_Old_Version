using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class Table : MonoBehaviourPunCallbacks
{
    public Deck draw_deck;
    public List<GameObject> discard;
    public Offensive_Card last_card;
    public int player_count;
    public Player pov_player;
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;
    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;
    public Player current_player;
    public GameObject gameOver;
    private bool reversed = false;
    private bool ready = true;
    LinkedListNode<Player> current;
    public LinkedList<Player> order = new LinkedList<Player>();
    public LinkedList<Photon.Realtime.Player> temp_order = new LinkedList<Photon.Realtime.Player>();
    public LinkedListNode<Photon.Realtime.Player> temp_current;
    void Start() {
        if (PlayerManager.LocalPlayerInstance == null && PhotonNetwork.IsMasterClient) {
            Debug.Log("B");
            foreach(Photon.Realtime.Player p in PhotonNetwork.PlayerList) {
                temp_order.AddLast(p);
            }
            temp_current = temp_order.First;
            for (int a = 0; a < temp_order.Count; a++) {
                Debug.Log("A");
                if (temp_current.Value.NickName == PhotonNetwork.NickName) {
                    Debug.Log("This player equals this player");
                    GameObject player1_object = PhotonNetwork.Instantiate("player", new Vector3(-8f, -4.4f, 1f), transform.rotation);
                    player1 = player1_object.GetComponent<Player>();
                    order.AddLast(player1);
                    player1.table = this;
                    temp_current = temp_current.Next ?? temp_current.List.First;
                    for (int b = 0; b < temp_order.Count - 1; b++) {
                        Debug.Log(b);
                        Debug.Log("C");
                        if (b == 0) {
                            GameObject player2_object = PhotonNetwork.Instantiate("player", new Vector3(-8f, 4.4f, 1f), transform.rotation);
                            player2 = player2_object.GetComponent<Player>();
                            order.AddLast(player2);
                            player2.table = this;
                            player2_object.GetComponent<PhotonView>().TransferOwnership(temp_current.Value);
                            temp_current = temp_current.Next ?? temp_current.List.First;
                        } else if (b == 1) {
                            GameObject player3_object = PhotonNetwork.Instantiate("player", new Vector3(8f, 4.4f, 1f), transform.rotation);
                            player3 = player3_object.GetComponent<Player>();
                            order.AddLast(player3);
                            player3.table = this;
                            player3_object.GetComponent<PhotonView>().TransferOwnership(temp_current.Value);
                            temp_current = temp_current.Next ?? temp_current.List.First;
                        } else if(b == 2) {
                            GameObject player4_object = PhotonNetwork.Instantiate("player", new Vector3(8f, -4.4f, 1f), transform.rotation);
                            player4 = player4_object.GetComponent<Player>();
                            order.AddLast(player4);
                            player4.table = this;
                            player4_object.GetComponent<PhotonView>().TransferOwnership(temp_current.Value);
                            temp_current = temp_current.Next ?? temp_current.List.First;
                        }
                    } break;
                } else {
                    temp_current = temp_current.Next ?? temp_current.List.First;
                }
            }
            player_count = Manager.PlayerCount;
            Create_Deck();
            //Create_Players();
            current = order.First;
            current_player = player1;
            StartCoroutine(Wait_For_Deck());
        }
        
    }
    public void Discard(GameObject card) {
        card.GetComponent<SpriteRenderer>().sortingOrder = discard.Count;
        discard.Add(card);
    }
    private void AddPlayer() {

    }
    private void Create_Players() {
        GameObject player = Resources.Load("Prefabs/player") as GameObject;
        if (player_count > 1) {
            GameObject player1_object = PhotonNetwork.Instantiate("player", new Vector3(-8f, -4.4f, 1f), transform.rotation);
            player1 = player1_object.GetComponent<Player>();
            player1.table = this;
            GameObject player2_object = PhotonNetwork.Instantiate("player", new Vector3(-8f, 4.4f, 1f), transform.rotation);
            player2 = player2_object.GetComponent<Player>();
            player2.table = this;
            order.AddLast(player1);
            order.AddLast(player2);
        }
        if (player_count > 2) {
            GameObject player3_object = PhotonNetwork.Instantiate("player", new Vector3(8f, 4.4f, 1f), transform.rotation);
            player3 = player3_object.GetComponent<Player>();
            player3.table = this;
            order.AddLast(player3);
            p3.gameObject.SetActive(true);
        }
        if (player_count == 4) {
            GameObject player4_object = PhotonNetwork.Instantiate("player", new Vector3(8f, -4.4f, 1f), transform.rotation);
            player4 = player4_object.GetComponent<Player>();
            player4.table = this;
            order.AddLast(player4);
            p4.gameObject.SetActive(true);
        }
    }
    IEnumerator Wait_For_Deck() {
        yield return new WaitUntil(() => draw_deck.draw_deck.Count == 100);
        Debug.Log("Deck == 100 " + draw_deck.draw_deck.Count);
        initial_deal();
    }
    private void Create_Deck() {
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
        StartCoroutine(NextPlayer());
    }
    IEnumerator NextPlayer() {
        current_player.StackCards();
        if (reversed) {
            current = current.Previous ?? current.List.Last;
        } else {
            current = current.Next ?? current.List.First;
        }
        current_player = current.Value;
        current_player.Draw();
        yield return new WaitUntil(() => ready);
        Update_Scores();
    }
    public void Skip() {
        current_player.StackCards();
        if (reversed) {
            current = current.Previous ?? current.List.Last;
        } else {
            current = current.Next ?? current.List.First;
        }
    }
    public void Reverse() {
        reversed = !reversed;
    }
    private void Update_Scores() {
        p1.text = player1.UpdateScore().ToString();
        p2.text = player2.UpdateScore().ToString();
        if (player3) {
            p3.text = player3.UpdateScore().ToString();
        }
        if (player4) {
            p4.text = player4.UpdateScore().ToString();
        }
        if (player1.score >= 21 && !current_player.StopWin()) {
            gameOver.SetActive(true);
            gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 wins!";
        }
        else if (player2.score >= 21 && !current_player.StopWin()) {
            gameOver.SetActive(true);
            gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Player 2 wins!";
        }
        else if (player3 && player3.score >= 21 && !current_player.StopWin()) {
            gameOver.SetActive(true);
            gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Player 3 wins!";
        }
        else if (player4 && player4.score >= 21 && !current_player.StopWin()) {
            gameOver.SetActive(true);
            gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Player 4 wins!";
        }
    }
    public void SetReady(bool a) {
        ready = a;
    }
    void Update() {
    }
}