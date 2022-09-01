using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private BoxCollider gunHitBoxCollider;

    [SerializeField]
    private Vector3[] colliderChangeSize;

    [SerializeField]
    private Vector3[] colliderChangeCenter;

    // Start is called before the first frame update
    void Start()
    {
        StartSettings();
    }

    private void StartSettings()
    {
        gunHitBoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        MissingObjClear();
    }

    private void MissingObjClear()
    {
        for (int nowEnemyListIndex = 0; nowEnemyListIndex < GameManager.Instance.enemyList.Count; nowEnemyListIndex++)
        {
            if (GameManager.Instance.enemyList[nowEnemyListIndex] == false)
            {
                GameManager.Instance.enemyList.Remove(GameManager.Instance.enemyList[nowEnemyListIndex]);
            }
        }
    }

    public void ChangeHitBoxSize(bool isChangeMachineGunHitBox)
    {
        if (isChangeMachineGunHitBox)
        {
            gunHitBoxCollider.size = colliderChangeSize[(int)GunState.MachineGun];
            gunHitBoxCollider.center = colliderChangeCenter[(int)GunState.MachineGun];
        }
        else 
        {
            gunHitBoxCollider.size = colliderChangeSize[(int)GunState.ShotGun];
            gunHitBoxCollider.center = colliderChangeCenter[(int)GunState.ShotGun];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.enemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.enemyList.Remove(other.gameObject);
        }
    }
}
