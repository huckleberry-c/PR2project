using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 声明变量
    public GameObject player;
    public Camera mainCamera;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    private float rotationX = 0f;
    private Rigidbody playerRb; // 添加刚体引用

    // Start is called before the first frame update
    void Start()
    {
        // 锁定并隐藏鼠标光标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 获取玩家刚体组件
        playerRb = player.GetComponent<Rigidbody>();
        if (playerRb == null)
        {
            // 如果没有刚体组件，添加一个
            playerRb = player.AddComponent<Rigidbody>();
        }
        // 设置刚体属性
        playerRb.freezeRotation = true; // 冻结刚体旋转
        playerRb.useGravity = true; // 使用重力
        playerRb.constraints = RigidbodyConstraints.FreezeRotation; // 冻结所有轴向的旋转
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        HandleMovement();
        HandleCameraRotation();
    }

    private void HandleMovement()
    {
        // 获取WASD输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 获取摄像机的前向和右向
        Vector3 cameraForward = mainCamera.transform.parent.forward;
        Vector3 cameraRight = mainCamera.transform.parent.right;

        // 确保在水平面上移动
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 计算最终移动方向
        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal);
        
        // 如果有输入才移动
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            // 使用MovePosition来移动玩家，这样可以考虑碰撞
            Vector3 targetPosition = playerRb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            playerRb.MovePosition(targetPosition);
        }

        // 让玩家始终跟随摄像机的水平旋转
        Vector3 cameraForwardHorizontal = mainCamera.transform.parent.forward;
        cameraForwardHorizontal.y = 0;
        player.transform.forward = cameraForwardHorizontal.normalized;
    }

    private void HandleCameraRotation()
    {
        // 处理鼠标输入，控制相机旋转
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        mainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        mainCamera.transform.parent.Rotate(Vector3.up * mouseX);
    }
}
