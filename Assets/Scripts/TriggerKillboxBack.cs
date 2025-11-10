using UnityEngine;

public class TriggerKillboxBack : MonoBehaviour
{
    public Animator control;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            control.SetBool("Go", false);
            control.SetBool("Back", true);

        }
    }

}
