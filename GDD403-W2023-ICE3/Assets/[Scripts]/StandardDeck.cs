using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class StandardDeck : Stack<GameObject>
{
    // Private Instance Members (fields)
    private readonly string[] _suits;
    private readonly string[] _ranks;
    private List<GameObject> _cardPrefabs;

    // Constructor
    public StandardDeck()
    {
        _suits = new[] { "Club", "Diamond", "Heart", "Spade" };
        _ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };
        _cardPrefabs = new List<GameObject>(); // creates an empty container of List<GameObject> type

        Load();
        Initialize();
    }

    // Public Properties (getters and setters)

    // Public Methods
    public void Initialize()
    {
        foreach (var card in _cardPrefabs)
        {
            var tempCard = MonoBehaviour.Instantiate(card);
            tempCard.SetActive(false);
            Push(tempCard);
        }
        
    }

    public void Display()
    {
        foreach (var card in this)
        {
            MonoBehaviour.print(card);
        }
    }

    // Private Methods
    private void Clean()
    {
        foreach (var card in this)
        {
            MonoBehaviour.Destroy(card);
        }

        Clear();
    }

    private void Load()
    {
        for (var i = 0; i < _suits.Length; i++)
        {
            var cardPrefab = Resources.Load<GameObject>($"Prefabs/Card/{_suits[i]}_{_ranks[i]}");
            var card = MonoBehaviour.Instantiate(cardPrefab);
            card.SetActive(false);
            _cardPrefabs.Add(card);
        }
    }
}
