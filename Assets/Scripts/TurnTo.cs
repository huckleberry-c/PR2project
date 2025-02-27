using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTo : MonoBehaviour
{
    [SerializeField]
    private Transform target; // 目标Transform
    
    [SerializeField]
    private float rotationSpeed = 5f; // 旋转速度，可在Inspector中调整

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // 计算朝向目标的方向
            Vector3 direction = target.position - transform.position;
            direction.y = 0; // 如果只需要水平方向的旋转，将y轴方向置为0

            // 如果方向向量不为零，则进行旋转
            if (direction != Vector3.zero)
            {
                // 计算目标旋转
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                
                // 平滑旋转
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
