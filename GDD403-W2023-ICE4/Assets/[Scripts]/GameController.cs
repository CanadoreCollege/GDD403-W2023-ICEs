using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private StandardDeck deck;

    // Start is called before the first frame update
    void Start()
    {
        deck = new StandardDeck(); // example of composition
    }
}
