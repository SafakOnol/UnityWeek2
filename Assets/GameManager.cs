using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState 
{
    NullState, 
    Intro, 
    MainMenu, 
    Game,
    WinState
}


public class GameManager : MonoBehaviour
{     
    static GameManager _instance = null;
    public delegate void OnStateChangeHandler();
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    protected GameManager() { }
    

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        if(OnStateChange != null)
        {
            OnStateChange();
        }
    }
    

}
