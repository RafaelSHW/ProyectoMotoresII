using UnityEngine;

public class TriggerKillBox : MonoBehaviour
{
    public Animator control;
    public GameObject TriggerDeRetorno;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            control.SetBool("Go", true);
            control.SetBool("Back", false);

            gameObject.SetActive(false); 
            TriggerDeRetorno.SetActive(true);

        }
    }

}