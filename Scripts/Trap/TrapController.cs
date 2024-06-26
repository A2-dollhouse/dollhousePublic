using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.player.OnDeath();
            GameManager.Instance.player.OnRespawn();
        }
    }
}