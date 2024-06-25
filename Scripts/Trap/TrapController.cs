using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.player.OnDeath();

            Collider[] colliders = transform.parent.GetComponentsInChildren<Collider>();
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }

            GameManager.Instance.player.OnRespawn();
        }
    }
}