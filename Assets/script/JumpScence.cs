using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 跳转到场景编号为1的方法
    public void JumpToScene1()
    {
        SceneManager.LoadScene(1);
    }
}
