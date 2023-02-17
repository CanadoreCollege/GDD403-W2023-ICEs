using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Transform> twoByFourLayout;
    public List<Transform> fourByFourLayout;
    public List<Transform> sixBySixLayout;

    public UIController uiController;
    public Transform cardParent;


    private StandardDeck deck;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GetComponent<UIController>();
        deck = new StandardDeck(); // example of composition
        cardParent = GameObject.Find("[CARDS]").transform;

        switch (uiController.difficulty)
        {
            case Difficulty.EASY:
            {
                List<Transform> randomPositions = new List<Transform>();

                for (var i = 0; i < twoByFourLayout.Count; i++)
                {
                    var randomIndex = Random.Range(0, twoByFourLayout.Count);
                    if (i != randomIndex)
                    {
                        (twoByFourLayout[i], twoByFourLayout[randomIndex]) = (twoByFourLayout[randomIndex], twoByFourLayout[i]);
                    }
                }

                for (var i = 0; i < 8; i++)
                {
                    if (i == 0 || i % 2 == 0)
                    {
                        var firstCard = deck.Pop();
                        firstCard.SetActive(true);
                        firstCard.GetComponent<Card>().Flip();
                        var secondCard = Instantiate(firstCard);
                        secondCard.transform.SetParent(cardParent);
                        firstCard.transform.position = twoByFourLayout[i].position;
                        secondCard.transform.position = twoByFourLayout[i+1].position;
                    }
                }
            }
                break;
            case Difficulty.NORMAL:
            {

            }
                break;
            case Difficulty.HARD:
            {

            }
                break;
        }
    }
}
