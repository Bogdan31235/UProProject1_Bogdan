using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera goCamera;

    private Rigidbody rb;

    private const float speedScale = 5f,
                    jumpForce = 8f,
                    turnSpeed = 90f;

    private float mouseX = 0f,
                  mouseY = 0f,
                  currentAngleX = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotateCharacter();
        MoveCharacter();
    }

    private void RotateCharacter()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0f, mouseX * turnSpeed * Time.deltaTime, 0f));

        currentAngleX += mouseY * turnSpeed * Time.deltaTime * -1f;
        currentAngleX = Mathf.Clamp(currentAngleX, -60f, 60f);

        goCamera.transform.localEulerAngles = new Vector3(currentAngleX, 0f, 0f);
    }

    private void MoveCharacter()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        direction = transform.TransformDirection(direction) * speedScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(direction.x , rb.velocity.y , direction.z);
    }


}
