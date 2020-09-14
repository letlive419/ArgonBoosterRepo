using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
   
    private void Awake()
    {
        int numOfMusPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numOfMusPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("loadNextScene", 3f);
    }

    // Update is called once per frame
    void loadNextScene()

    {
        SceneManager.LoadScene(1);
    }
}
