using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcontroller : MonoBehaviour
{
    public GameObject cam;

    Quaternion StartingRotation;

    float Ver, Hor, Jump, RotHor, RotVer;

    bool isGround;

    public float Speed = 10, JumpSpeed = 200, senssensitivity = 5;

    private void Start()
    {
        StartingRotation = transform.rotation;
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
    void FixedUpdate()
    {
        RotHor += Input.GetAxis("Mouse X") * senssensitivity;
        RotVer += Input.GetAxis("Mouse Y") * senssensitivity;
        // ����������� �� ������� ���� ������(����� �� ���� �����������)
        RotVer = Mathf.Clamp(RotVer, -60, 60);  //(��������, ������� ������������, ����������� "��", ����������� "��")
        Quaternion RotY = Quaternion.AngleAxis(RotHor, Vector3.up);
        Quaternion RotX = Quaternion.AngleAxis(-RotVer, Vector3.right);

        cam.transform.rotation = StartingRotation * transform.rotation * RotX;
        transform.rotation = StartingRotation * RotY;

        if (isGround)
        {
            //���������� �������� (������ (W) = 1, ����� (S) = -1)
            //Time.deltaTime ��� ����������� ������, �� ���� �� 1 � -1, � 0.** � -0.**
            Ver = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            Hor = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;
            GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(Hor, 0, Ver));
    }
}
