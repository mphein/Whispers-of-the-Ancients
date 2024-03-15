using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static Exit exitInstance;
    public GameObject winScreen;
    bool canExit = false;

    void Awake()
    {
        exitInstance = this;
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player" && canExit) Win();
    }

    void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void WinConditionMet()
    {
        canExit = true;
    }

}
