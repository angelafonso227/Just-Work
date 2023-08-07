using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck1: MonoBehaviour
{
    public List<Sprite> DeckOfCards;
    public Sprite Blind;
    public List<Sprite> Shoe;
    private Dictionary<string, int> cardValues;
    private List<Sprite> dealtCards;
    private int remainingCards;
    private TextMeshProUGUI cardsRemainingText;

    void Start()
    {
        cardValues = new Dictionary<string, int>
        {
            { "CARTAS_0", 11 },
            { "CARTAS_1", 2 },
            { "CARTAS_2", 3 },
            { "CARTAS_3", 4 },
            { "CARTAS_4", 5 },
            { "CARTAS_5", 6 },
            { "CARTAS_6", 7 },
            { "CARTAS_7", 8 },
            { "CARTAS_8", 9 },
            { "CARTAS_9", 10 },
            { "CARTAS_10", 10 },
            { "CARTAS_11", 10 },
            { "CARTAS_12", 10 },
            { "CARTAS_13", 11},
            { "CARTAS_14", 2},
            { "CARTAS_15", 3},
            { "CARTAS_16", 4},
            { "CARTAS_17", 5},
            { "CARTAS_18", 6},
            { "CARTAS_19", 7},
            { "CARTAS_20", 8},
            { "CARTAS_21", 9},
            { "CARTAS_22", 10},
            { "CARTAS_23", 10},
            { "CARTAS_24", 10},
            { "CARTAS_25", 10},
            { "CARTAS_26", 11},
            { "CARTAS_27", 2},
            { "CARTAS_28", 3},
            { "CARTAS_29", 4},
            { "CARTAS_30", 5},
            { "CARTAS_31", 6},
            { "CARTAS_32", 7},
            { "CARTAS_33", 8},
            { "CARTAS_34", 9},
            { "CARTAS_35", 10},
            { "CARTAS_36", 10},
            { "CARTAS_37", 10},
            { "CARTAS_38", 10},
            { "CARTAS_39", 11},
            { "CARTAS_40", 2},
            { "CARTAS_41", 3},
            { "CARTAS_42", 4},
            { "CARTAS_43", 5},
            { "CARTAS_44", 6},
            { "CARTAS_45", 7},
            { "CARTAS_46", 8},
            { "CARTAS_47", 9},
            { "CARTAS_48", 10},
            { "CARTAS_49", 10},
            { "CARTAS_50", 10},
            { "CARTAS_51", 10}  
        };

        Shoe = new List<Sprite>(DeckOfCards);
        Shuffle(Shoe);
        dealtCards = new List<Sprite>();
        remainingCards = 312;
        cardsRemainingText = GetComponent<TextMeshProUGUI>();
        cardsRemainingText.text = remainingCards.ToString();
    }

    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count -1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand]=temp;
        }
    }

    public void DealCard()
    {
        if (Shoe.Count > 0)
        {
            Sprite card = Shoe[0];
            Shoe.RemoveAt(0); 
            dealtCards.Add(card);
            Debug.Log("Dealt card: " + card.name);
            remainingCards--;
            Debug.Log("Remaining cards: " + remainingCards);
            cardsRemainingText.text = remainingCards.ToString();
        }
        else
        {
            Debug.Log("No more cards to deal.");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Before Shuffle => " + string.Join(", ", Shoe));
            //Shuffle(Shoe);
            Debug.Log("After Shuffle => "+string.Join(",", Shoe ));
        }
    }

}
