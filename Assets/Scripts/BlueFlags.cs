using UnityEngine;

public class BlueFlags : MonoBehaviour
{
    public int pointValue = 2;
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            GameManager.Instance.AddPoint(pointValue);
            collected = true;
            GetComponent<Collider>().enabled = false;

            // Optional: Fade out or disable renderer
            // GetComponent<MeshRenderer>().enabled = false;
        }
    }
}