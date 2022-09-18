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

    private int[] maxBulletCount = new int[2];
    private int[] nowBulletCount = new int[2];

    private bool isShooting;

    private WaitForSeconds waitMachineGun;
    private WaitForSeconds waitShotGun;

    // Start is called before the first frame update
    void Start()
    {
        StartSettings();
    }

    private void Update()
    {
        GunShoot();
        MissingObjClear();
    }

    private void GunShoot()
    {
        if (Input.GetKey(KeyCode.Z) && isShooting == false)
        {
            isShooting = true;
            StartCoroutine(Shooting());
        }
    }

    private IEnumerator Shooting()
    {
        var gameManagerInstance = GameManager.Instance;
        gameManagerInstance.gunObject[(int)gameManagerInstance.nowGunState].SetActive(true);
        int damage = (gameManagerInstance.nowGunState == GunState.MachineGun) ?  2 : 6;

        for (int nowEnemyListIndex = 0; nowEnemyListIndex < gameManagerInstance.enemyList.Count; nowEnemyListIndex++)
        {
            gameManagerInstance.enemyList[nowEnemyListIndex].GetComponent<Enemy>().Hp -= damage;
        }

        if (gameManagerInstance.nowGunState == GunState.MachineGun)
        {
            yield return waitMachineGun;
            nowBulletCount[(int)GunState.MachineGun]--;
        }
        else 
        {
            yield return waitShotGun;
            nowBulletCount[(int)GunState.ShotGun]--;
        }

        if (gameManagerInstance.nowGunState == GunState.MachineGun && nowBulletCount[(int)GunState.MachineGun] <= 0)
        {

        }
        else if(gameManagerInstance.nowGunState == GunState.ShotGun&& nowBulletCount[(int)GunState.ShotGun] <= 0)
        {

        }

        isShooting = false;
    }

    private void StartSettings()
    {
        maxBulletCount[(int)GunState.MachineGun] = 35;
        maxBulletCount[(int)GunState.ShotGun] = 15;

        nowBulletCount[(int)GunState.MachineGun] = maxBulletCount[(int)GunState.MachineGun];
        nowBulletCount[(int)GunState.ShotGun] = maxBulletCount[(int)GunState.ShotGun];

        waitMachineGun = new WaitForSeconds(0.2f);
        waitShotGun = new WaitForSeconds(1f);
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
