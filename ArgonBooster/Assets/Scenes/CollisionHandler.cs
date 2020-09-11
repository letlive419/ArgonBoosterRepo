using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        commenceDeathSequence();
    }

    private void commenceDeathSequence()
    {
        SendMessage("stopPlayerMovement");
        Invoke("loadScene", 3f);
        DeathFX.SetActive(true);
    }
    private void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
