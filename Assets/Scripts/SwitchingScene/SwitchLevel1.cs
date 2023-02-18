using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel1 : MonoBehaviour
{
    private bool go;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
