using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private RectTransform deathScreen;
    [SerializeField] private Text scoreText;
    
    public void ShowDeathScreen()
    {
        deathScreen.gameObject.SetActive(true);
    }

    public void SetScore(float score)
    {
        scoreText.text = $"{score:F1} M";
    }
}