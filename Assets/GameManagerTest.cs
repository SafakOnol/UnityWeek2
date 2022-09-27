using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    GameManager GM;

    private void Awake()
    {
        GM = GameManager.Instance;
        GM.OnStateChange += HandleOnStateChange;
        Debug.Log("State on Awake: " + GM.gameState);
        GM.SetGameState(GameState.Intro);

    }

    void Start()
    {
        Debug.Log("Current state on Start: " +GM.gameState);    
    }

    public void HandleOnStateChange()
    {
        Debug.Log("State on Awake: " + GM.gameState);
    }
}
