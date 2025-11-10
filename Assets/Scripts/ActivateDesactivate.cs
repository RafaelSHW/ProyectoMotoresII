using UnityEngine;

public class ActivateDesactivate : MonoBehaviour
{
    public GameObject TriggerA;
    public GameObject TriggerB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
        
            TriggerA.SetActive(false);
            TriggerB.SetActive(true);
        
        }
    }
}
