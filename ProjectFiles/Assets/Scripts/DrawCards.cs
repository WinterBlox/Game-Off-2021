using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{

    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public Button drawbutton;

    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        cards.Add(Card1);
        cards.Add(Card2);    
    }

    public void OnClick ()
    {
        GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        playerCard.transform.SetParent(PlayerArea.transform, false);
        playerCard.tag = "PlrCard";

        GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        enemyCard.transform.SetParent(EnemyArea.transform, false);
        enemyCard.tag = "OppCard";
        
        
    }
    
}
