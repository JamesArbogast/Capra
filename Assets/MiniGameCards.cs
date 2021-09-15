using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCards : MonoBehaviour
{

    private int cardNumber;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite[] cardSymbols;
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject[] cards;



    // Start is called before the first frame update
    void Start()
    {
        Sprite[] cardSymbols = new Sprite[] {sprite1, sprite2, sprite3};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ClickCard ()
    {
        var symbol = cardSymbols[Random.Range(0,3)];
    }
}
