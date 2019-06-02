using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameUi gameUi; 

    private void Awake()
    {
        player.OnDeathEvent += () =>
        {
            gameUi.ShowDeathScreen();
        };
    }

    private void Update()
    {
        if (player.Alive)
            gameUi.SetScore(player.transform.position.z);
    }
}