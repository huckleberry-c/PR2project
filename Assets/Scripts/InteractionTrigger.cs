using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    //该代码使InteractionArm碰撞到CanInteraction标签时显示其上挂载的物体；碰撞到Pick标签时提示拾取
    [SerializeField]
    private GameObject pick; // 可拾取提示物体
    
    private bool pickShow = false; // 控制pick显示状态

    // Start is called before the first frame update
    void Start()
    {
        // 确保初始状态是隐藏的
        if (pick != null)
        {
            pick.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 检测F键按下
        if (Input.GetKeyDown(KeyCode.F) && pickShow)
        {
            showPick(false);
        }
    }

    // 控制pick物体的显示/隐藏
    private void showPick(bool show)
    {
        if (pick != null)
        {
            pickShow = show;
            pick.SetActive(show);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 处理 CanInteraction 标签的物体
        if (other.CompareTag("CanInteraction"))
        {
            ShowInteraction showInteraction = other.GetComponent<ShowInteraction>();
            if (showInteraction != null)
            {
                showInteraction.showOn();
            }
        }
        
        // 处理 Interaction 标签的物体
        if (other.CompareTag("Pick"))
        {
            showPick(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 处理 CanInteraction 标签的物体
        if (other.CompareTag("CanInteraction"))
        {
            ShowInteraction showInteraction = other.GetComponent<ShowInteraction>();
            if (showInteraction != null)
            {
                showInteraction.showOff();
            }
        }
        
        // 处理 Interaction 标签的物体
        if (other.CompareTag("Pick"))
        {
            showPick(false);
        }
    }
}
