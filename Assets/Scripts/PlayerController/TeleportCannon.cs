using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportCannon : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene("Dmax");
    }
}
