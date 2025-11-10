using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    public GameObject player;
    public Transform repawn;
    public int nivel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            //alternativa 1
            player.transform.position = repawn.position;

            //alternativa 2 y reasignar despues a boton de retry
            //Scene reinicioNilvel = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(reinicioNilvel.name);
        }
    }
}
