using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject m_FirstButton;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(m_FirstButton);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
