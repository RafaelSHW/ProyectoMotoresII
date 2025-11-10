using UnityEngine;

public class TriggerKillBox : MonoBehaviour
{
    public Animator control;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            control.SetBool("Go", true);
            control.SetBool("Back", false);

        }
    }

}
