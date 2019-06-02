using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            player.Die();
        }
    }
}