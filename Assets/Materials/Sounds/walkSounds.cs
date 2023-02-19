using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSounds : MonoBehaviour
{
    private SoundManager _soundManager;
    private PlayerController _playerController;
    private void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    public void StepSound()
    {
        if (_playerController.isGrounded)
        {
            _soundManager.PlaySound("Walk");
        }
        
    }
}
