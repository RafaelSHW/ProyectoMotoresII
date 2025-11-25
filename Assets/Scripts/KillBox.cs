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
        if (collision.gameObject.CompareTag("Player")) {
            //alternativa 1
            

            //alternativa 2 y reasignar despues a boton de retry
            //Scene reinicioNilvel = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(reinicioNilvel.name);
        }
    }
    IEnumerator Dead()
    {
        playerAnim.SetBool("Muerte", true);

        yield return new WaitForSeconds(1f);       
        player.transform.position = repawn.position;
        playerAnim.SetBool("Muerte", false);
        playerAnim.SetFloat("Camina", 0f);
    }
}
