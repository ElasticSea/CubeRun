using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private RectTransform deathScreen;
    [SerializeField] private Text scoreText;
    
    public void ShowDeathScreen()
    {
        StartCoroutine(RestartSceneInSeconds(2));
    }

    private IEnumerator RestartSceneInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetScore(float score)
    {
        scoreText.text = $"{score:F1} M";
    }
}