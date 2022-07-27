using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject pause_menu;

    private bool paused = false;



    public void PauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pause_menu.SetActive(true);
            paused = true;
        }
    }

    public void UnpauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            pause_menu.SetActive(false);
            paused = false;
        }
    }

}
