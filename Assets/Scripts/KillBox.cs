using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillBox : MonoBehaviour
{
    public GameObject player;
    public Transform repawn;
    public int nivel;
    public Animator playerAnim;

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public IEnumerator Dead()
    {
        playerAnim.SetBool("Muerte", true);

        yield return new WaitForSeconds(1f);
        player.transform.position = repawn.position;
        playerAnim.SetBool("Muerte", false);
        playerAnim.SetFloat("Camina", 0f);
    }

    public void RespawnWithoutDeathAnim()
    {
        player.transform.position = repawn.position;
        playerAnim.SetBool("Muerte", false);
        playerAnim.SetFloat("Camina", 0f);
    }
}
