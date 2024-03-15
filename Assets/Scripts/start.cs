using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class start : MonoBehaviour
{
    public void GTG()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Gameplay"); 
    }
}