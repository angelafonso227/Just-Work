using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Deck1: MonoBehaviour
{
    public List<Sprite> DeckOfCards;
    public Sprite Blind;
    public List<Sprite> Shoe;
    private Dictionary<string, int> cardValues;
    private List<Sprite> dealtCards;
    private int remainingCards;
    private TextMeshProUGUI cardsRemainingText;
    private GameObject panelFichas;
	public GameObject menuHSDS;
    private Image playerCard1;
    private Image playerCard2;
    private Image dealerCard1;
    private Image dealerCard2;
    private Image dealerBlind;
    public GameObject dealerBlindCard;
    private Image playerHitCard1;
    private Image playerHitCard2;
    private Image playerHitCard3;
    private Image playerHitCard4;
    private int nextHitCardIndex = 0;
    private int playerTotalSum;
    private int casinoTotalSum;


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
        panelFichas = GameObject.Find("PanelDeFichas");
        playerCard1 = GameObject.Find("PC1").GetComponent<Image>();
        playerCard2 = GameObject.Find("PC2").GetComponent<Image>();
        dealerCard1 = GameObject.Find("CC1").GetComponent<Image>();
        dealerCard2 = GameObject.Find("CC2").GetComponent<Image>();
        dealerBlind = GameObject.Find("CCB").GetComponent<Image>();
        playerHitCard1 = GameObject.Find("PHC1").GetComponent<Image>(); 
        playerHitCard2 = GameObject.Find("PHC2").GetComponent<Image>();
        playerHitCard3 = GameObject.Find("PHC3").GetComponent<Image>();  
        playerHitCard4 = GameObject.Find("PHC4").GetComponent<Image>(); 
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

    public IEnumerator DealCard()
    {
        for (int i = 0; i < 4; i++)
        {

            if (Shoe.Count > 0)
            {
                Sprite card = Shoe[0];
                Shoe.RemoveAt(0); 
                dealtCards.Add(card);
                switch (i)
                {
                    case 0:
                        playerCard1.sprite = card;
						playerTotalSum += GetCardValue(card);
                        break;
                    case 1:
                        dealerBlind.sprite = Blind;
                        dealerCard1.sprite = card;
                        casinoTotalSum += GetCardValue(card);
                        break;
                    case 2:
                        playerCard2.sprite = card;
						playerTotalSum += GetCardValue(card);
                        break;
                    case 3:
                        dealerCard2.sprite = card;
                        casinoTotalSum += GetCardValue(card);
                        break;
                }
                //Debug.Log("Dealt card: " + card.name);
                remainingCards--;
                panelFichas.SetActive(false);
                Debug.Log("Remaining cards: " + remainingCards);
                cardsRemainingText.text = remainingCards.ToString();
            }
            else
            {
                Debug.Log("No more cards to deal.");
            }
            yield return new WaitForSeconds(0.5f);
			Debug.Log("Player Total Sum: " + playerTotalSum);
            Debug.Log("Player Total Sum: " + casinoTotalSum);

        }
		menuHSDS.SetActive(true);
    }

    public void OnStayButtonClick()
    {
        dealerBlindCard.SetActive(false);
        menuHSDS.SetActive(false);
    }

    public void OnHitButtonClick()
	{
		if (nextHitCardIndex < 4 && Shoe.Count > 0)
		{
			Sprite card = Shoe[0];
			Shoe.RemoveAt(0);
			dealtCards.Add(card);
			int cardValue = GetCardValue(card);
        	playerTotalSum += cardValue;

			switch (nextHitCardIndex)
			{
				case 0:
					playerHitCard1.sprite = card;
					break;
				case 1:
					playerHitCard2.sprite = card;
					break;
				case 2:
					playerHitCard3.sprite = card;
					break;
				case 3:
					playerHitCard4.sprite = card;
					break;
			}
			nextHitCardIndex++;
			remainingCards--;
			cardsRemainingText.text = remainingCards.ToString();

			Debug.Log("Player Total Sum: " + playerTotalSum);
			if (playerTotalSum > 21)
			{
				Debug.Log("Player Bust");
                
			}
		}
	}   

	private int GetCardValue(Sprite card)
	{
		// Implementa la lógica para obtener el valor de la carta usando el diccionario cardValues
		if (cardValues.ContainsKey(card.name))
		{
			return cardValues[card.name];
		}
		else
		{
			Debug.LogError("Card value not found: " + card.name);
			return 0; // Valor predeterminado en caso de no encontrar la carta en el diccionario
		}
	} 

    public void StartDealCard()
    {
        StartCoroutine(DealCard());
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
