using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += (scene, loadMode) => 
        {
            Debug.Log("Scene Loaded  - " + scene.name);
            StartCoroutine(OnLevelLoad());
        };
    }

    /// <summary>
    /// Stuffs to do after level scene load
    /// </summary>
    /// <returns></returns>
    IEnumerator OnLevelLoad()
    {
        yield return null;

        Controller.self.playerController.playerMovement.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
