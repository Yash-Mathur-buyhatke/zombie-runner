using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    public void HandleDeath()
    {
     gameOverCanvas.enabled = true;
     Time.timeScale = 0;
     FindObjectOfType<WeaponSwitcher>().enabled = false;        // learning
     Cursor.lockState = CursorLockMode.None;  
     Cursor.visible = true;
    }
}
