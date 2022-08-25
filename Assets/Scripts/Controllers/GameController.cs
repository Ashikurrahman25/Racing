using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Controller.self.audioController.PlayBG();
    }

    public void EndGame()
    {
                
    }

    public void PauseGame()
    {
        
    }
}
