using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera MainCamera;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = MainCamera.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.Hp -= 1;
        }
        else if (other.gameObject.CompareTag("ObjDestroy"))
        {
            GameManager.Instance.Hp -= 3;
        }
    }
}
