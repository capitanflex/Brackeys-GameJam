using UnityEngine;

public class ClosePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    public void Close()
    {
        pauseMenu.SetActive(false);
    }
}
