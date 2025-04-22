using UnityEngine;

public class StartGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.CallRaceStart();
        }
    }
}