using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Animation endTimerAnim;
    [SerializeField] private GameObject startEndPanel;

    private PlayerController _playerController;
    private CameraController _cameraController;
    private Interaction _interaction;



    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _cameraController = FindObjectOfType<CameraController>();
        _interaction = FindObjectOfType<Interaction>();
        
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            startEndPanel.SetActive(true);
            endTimerAnim.Play("StartGame");
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            startEndPanel.SetActive(true);
            endTimerAnim.Play("StartGame");
            
        }
        
    }

    public void Loose()
    {
        endTimerAnim.Play("EndGame");
        Cursor.lockState = CursorLockMode.None;
        CanMove(false);
        
    }

    public void RetryTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CanMove(bool can)
    {
        
        _playerController.canMove = can;
        _cameraController.canMove = can;
        _interaction.canMove = can;
    }
}
