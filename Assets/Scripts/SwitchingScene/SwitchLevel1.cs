using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel1 : MonoBehaviour
{
    public bool final;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && final)
        {
            SceneManager.LoadScene(1);
        }
    }
}
