using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_main : MonoBehaviour
{
    public GameObject menuMain;
    public bool isStop = true;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    public AudioSource music4;
    // Start is called before the first frame update
    void Start()
    {
        // 游戏开始时锁定鼠标
        LockCursor();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStop)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        menuMain.SetActive(true);
        isStop = false;
        Time.timeScale = 0;
        // 解锁鼠标以便操作菜单
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        menuMain.SetActive(false);
        isStop = true;
        Time.timeScale = 1;
        // 重新锁定鼠标用于游戏
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rsume()
    {
        ResumeGame();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
