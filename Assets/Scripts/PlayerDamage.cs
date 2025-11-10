using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float hitCooldown = 1f; 
    private bool canBeHit = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill") && canBeHit)
        {
            GameManager.instance.PlayerHit();
        }
    }

    /*void TakeDamage()
    {
        GameManager.instance.PlayerHit();
        StartCoroutine(HitCooldown());
    }

    System.Collections.IEnumerator HitCooldown()
    {
        canBeHit = false;
        yield return new WaitForSeconds(hitCooldown);
        canBeHit = true;
    }*/
}
