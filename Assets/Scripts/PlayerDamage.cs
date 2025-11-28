using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public float hitCooldown = 1f;
    private bool canBeHit = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill") && canBeHit)
        {
            KillBox killer = collision.gameObject.GetComponent<KillBox>();
            if (killer != null)
            {
                TakeDamage(killer);
            }
        }
    }

    void TakeDamage(KillBox killer)
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.PlayerHit(killer);
        }

        StartCoroutine(HitCooldown());
    }

    IEnumerator HitCooldown()
    {
        canBeHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canBeHit = true;
    }
}