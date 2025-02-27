using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionObject; // 可在Inspector中拖入的GameObject

    // 显示或隐藏物体
    public void show(bool isShow)
    {
        if (interactionObject != null)
        {
            interactionObject.SetActive(isShow);
        }
    }

    // 显示物体
    public void showOn()
    {
        show(true);
    }

    // 隐藏物体
    public void showOff()
    {
        show(false);
    }
}
