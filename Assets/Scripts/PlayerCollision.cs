using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameover; 
    public GameObject achievement; 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy, triggering GameOver and Achievement.");
            GameOver();
            UnlockAchievement("First Death");
        }
    }
    void GameOver()
    {
        gameover.SetActive(true);
        Time.timeScale = 0; 
    }
    void UnlockAchievement(string achievementName)
    {
        achievement.SetActive(true);
        Invoke(nameof(HideAchievementPopup), 1f); 
    }
    void HideAchievementPopup()
    {
        achievement.SetActive(false);
    }

}
