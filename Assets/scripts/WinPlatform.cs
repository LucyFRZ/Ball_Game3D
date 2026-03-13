using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    public GameObject winText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            winText.SetActive(true);
        }
    }
}
