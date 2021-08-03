using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DeckState { START, SHUFFLE_DECK, START_HAND, REMOVE_CARD, ADD_CARD, ADD_ENERGY, REMOVE_ENERGY}

public class DeckManager : MonoBehaviour
{
    [SerializeField] private DeckInventory inventory;
    [SerializeField] private EnemyController enemy;
    [SerializeField] private PlayerController player;

    public DeckState state;
  
    public int startEnergy, maxEnergy, currentEnergy;
    public int maxHand = 5;

    private int cardPosition;

    private float moveSpeed;

    [SerializeField] private GameObject handHolder;

    public RectTransform discardPosition;

    public GameObject[] cards;
    public GameObject tempCard;

   
    [SerializeField] public List<GameObject> cardsInPlay;
    [SerializeField] public List<GameObject> dealingOrder;
    [SerializeField] public List<GameObject> discardPile;
    [SerializeField] private List<GameObject> cardPlaced;

    public bool handPlaced;

    [SerializeField] private Button endTurnButton;
    [SerializeField] private TextMeshProUGUI energyText;

    private bool startFinished = false;
    [SerializeField] public bool hovering = false;
    private void OnEnable()
    {
        if (startFinished == true)
        {
            inventory = FindObjectOfType<DeckInventory>();
            enemy = FindObjectOfType<EnemyController>();

            cardsInPlay = new List<GameObject>();
            dealingOrder = new List<GameObject>();
            discardPile = new List<GameObject>();
            cardPlaced = new List<GameObject>();

            discardPosition = GameObject.Find("DiscardPosition").GetComponent<RectTransform>();
            energyText = GameObject.Find("PlayerEnergyText").GetComponent<TextMeshProUGUI>();

            cards = inventory.currentDeck.ToArray();

            for (int i = 0; i < cards.Length; i++)
            {
                //Debug.Log(cards[i].name);
                dealingOrder.Add(cards[i]);
                cards[i].SetActive(false);
            }

            endTurnButton.enabled = false;
            handPlaced = false;

            state = DeckState.START;
            StartCoroutine(StartHand());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<DeckInventory>();
        enemy = FindObjectOfType<EnemyController>();

        cardsInPlay = new List<GameObject>();
        dealingOrder = new List<GameObject>();
        discardPile = new List<GameObject>();
        cardPlaced = new List<GameObject>();

        discardPosition = GameObject.Find("DiscardPosition").GetComponent<RectTransform>();
        energyText = GameObject.Find("PlayerEnergyText").GetComponent<TextMeshProUGUI>();

        cards = inventory.currentDeck.ToArray();

        for (int i = 0; i < cards.Length; i++)
        {
            //Debug.Log(cards[i].name);
            dealingOrder.Add(cards[i]);
            cards[i].SetActive(false);
        }

        endTurnButton.enabled = false;
        handPlaced = false;

        state = DeckState.START;
        StartCoroutine(StartHand());

        startFinished = true;
    }

    public void ShuffleCards()
    {
        for (int i = 0; i < cards.Length - 1; i++)
        {
            int rnd = Random.Range(i, cards.Length);
            tempCard = cards[rnd];
            cards[rnd] = cards[i];
            cards[i] = tempCard;
        }
    }

    public IEnumerator StartHand()
    {
        state = DeckState.START_HAND;

       //Debug.Log("Start hand setup");

        //START ENERGY and MAX ENERGY
        if (startEnergy > maxEnergy)
        {
            //Debug.Log("Resetting Energy");
            //Resets energy per hand unless an energy boost was played
            maxEnergy = startEnergy;
            currentEnergy = maxEnergy;

            energyText.text = $"{currentEnergy.ToString("F0")}/{maxEnergy.ToString("F0")}";
        }

        yield return new WaitForSeconds(0.2f);

        //SHUFFLE DECK
        StartCoroutine(ShuffleDeck());

    }

    private IEnumerator ShuffleDeck()
    {
       // Debug.Log("ShufflingDeckFunction");

        state = DeckState.SHUFFLE_DECK;

        CardDisplay[] _cards = FindObjectsOfType<CardDisplay>();

        for (cardPosition = 0; cardPosition < cards.Length; cardPosition++)
        {
            ShuffleCards();

            foreach (CardDisplay cardDisplayed in _cards)
            {
               // Debug.Log("Shuffling Deck Now" + cards[cardPosition].name);

                dealingOrder.Add(cards[cardPosition]);

               // Debug.Log($"Adding {cards[cardPosition].name} to the queue");
            }
        }

        yield return new WaitForSeconds(1);

        //ADD CARDS TO HAND
        StartCoroutine(AddCardsToHand());
    }

    private IEnumerator AddCardsToHand()
    {
       // Debug.Log("Adding card function");
        state = DeckState.ADD_CARD;
       // Debug.Log("I am in add cards to hand function");

        for (int i = 0; i < dealingOrder.Count; i++)
        {
           // Debug.Log("I am calling Card Enter");
            while (dealingOrder.Count > 0)
            {
                StartCoroutine(CardEnter(dealingOrder[i]));
                yield return new WaitForSeconds(1);
            }
        }
    }

    private IEnumerator CardEnter(GameObject card)
    {
        //turn on object
        if (dealingOrder.Count > 0)
        {
            card.SetActive(true);
            dealingOrder.Remove(card);
            cardsInPlay.Add(card);
            //StartCoroutine(AddCardsToHand());

            yield return new WaitForSeconds(1);
        }
        else
        {
            //Debug.Log("No More cards to add");
            yield return null;
        }


        //play size increase animtion



        //move transform from the decks position > hand position
        //track rotate object position

        
    }

    private void Update()
    {
       // CardPlacedCheck();
        DiscardPile();
    }

    public void CardPlacedCheck(GameObject card)
    {
        cardPlaced.Add(card);

       // Debug.Log($"Cards placed in their spot : {cardPlaced.Count}");

        if (cardPlaced.Count == maxHand)
        {
            endTurnButton.enabled = true;
            handPlaced = true;
        } 
    }

    private void DiscardPile()
    {
        if (discardPile.Count > 0)
        {
            for (int i = 0; i < discardPile.Count; i++)
            {
                                
                dealingOrder.Add(discardPile[i]);
                
                for (int j = 0; j < dealingOrder.Count; j++)
                { 
                    discardPile.Remove(dealingOrder[j]);
                   
                    dealingOrder[j].GetComponent<CardMove>().ResetCard();
                    //Debug.Log("Restting Cards");     
                }
            }
        }
    }

    public IEnumerator DiscardCard(GameObject card)
    {
        state = DeckState.REMOVE_CARD;


        card.GetComponent<CardMove>().nearestHandSpot.spotTaken = false;
        card.GetComponent<CardMove>().nearestHandSpot.gameObject.SetActive(true);

        discardPile.Add(card);
        cardsInPlay.Remove(card);
        cardPlaced.Remove(card);

        //Debug.Log(card.name + " removing card");

        //for each card shrink scale and pull transform towards discard pile



        //REMOVE ENERGY
        //while playing animation remove current energy equal to card.energy

        currentEnergy -= card.GetComponent<CardDisplay>().card.energyCost;
        energyText.text = $"{currentEnergy.ToString("F0")}/{maxEnergy.ToString("F0")}";

        yield return null;
    }

    private IEnumerator DiscardMove(GameObject card)
    {
        //Debug.Log("Moving card to discard position before resetting");
        RectTransform cardPosition = card.GetComponent<RectTransform>();
        RectTransform spotPosition = discardPosition;
        Vector2 velocity = Vector2.zero;

        cardPosition.anchoredPosition = Vector2.SmoothDamp(cardPosition.anchoredPosition, spotPosition.anchoredPosition, ref velocity, 0.3f); //movetowards the nearest spot

        if (cardPosition.anchoredPosition == spotPosition.anchoredPosition)
        {
            //Debug.Log("Turn Off Obj");

            DiscardPile();
        }

        yield return new WaitForSeconds(1f);
    }
   
    public IEnumerator ResetHand()
    {
        currentEnergy = maxEnergy;
        player.block = 0;
        

        energyText.text = $"{currentEnergy.ToString("F0")}/{maxEnergy.ToString("F0")}";

        for (int i = 0; i < cardsInPlay.Count; i++)
        {
            while (cardsInPlay.Count > 0)
            {
                //Debug.Log("Shifting from play to dealing order");

                cardsInPlay[i].gameObject.GetComponent<CardMove>().nearestHandSpot.spotTaken = false;
                cardsInPlay[i].gameObject.GetComponent<CardMove>().nearestHandSpot.gameObject.SetActive(true);
                cardsInPlay[i].gameObject.GetComponent<CardMove>().ResetCard();
                dealingOrder.Add(cardsInPlay[i]);
                cardsInPlay.Remove(cardsInPlay[i]);

                if (cardsInPlay.Count > 0)
                {
                    cardPlaced.Remove(cardsInPlay[i]);
                }
                else
                {
                    cardPlaced.RemoveAt(0);
                }
                

                yield return new WaitForSeconds(.25f);
            }

            if (cardsInPlay.Count <= 0)
            {
                StartCoroutine(AddCardsToHand());
                yield return null;
            }

        }
     

        
    }

    //RESET ENERGY TO MAX ENERGY
    //ADD CARDS TO HAND

    public void EndRoundButton()
    { 
        handPlaced = false;

        if (enemy.health > 0)
        {
            enemy.StartCoroutine(enemy.Attack(gameObject));
        }

        endTurnButton.enabled = false;
    }

}
