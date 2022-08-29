using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnDirection
{
    Down,
    Left,
    Right,
    Up
}

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���� �ִ� ���� ��Ÿ��")]
    private float maxSpawnCoolTime;

    [SerializeField]
    [Tooltip("���� ���� ��Ÿ��")]
    private float nowSpawnCoolTime;

    [SerializeField]
    [Tooltip("�ð��� ��ȯ�� �� ������Ʈ")]
    private GameObject enemyObj;

    [SerializeField]
    [Tooltip("��ȯ ��ġ")]
    private GameObject[] enemySpawnerObjs;

    // Update is called once per frame
    void Update()
    {
        Spawn();    
    }

    private void Spawn()
    {
        if (GameManager.Instance.nowGameState == GameState.Playing)
        {
            nowSpawnCoolTime += Time.deltaTime;
            if (nowSpawnCoolTime >= maxSpawnCoolTime)
            {
                int randSpawnerIndex = Random.Range(0, 4);
                Vector3 spawnRangeColliderSize = enemySpawnerObjs[randSpawnerIndex].GetComponent<BoxCollider>().size;
                Vector3 spawnRangeColliderCenter = enemySpawnerObjs[randSpawnerIndex].GetComponent<BoxCollider>().center;

                float posX = enemySpawnerObjs[randSpawnerIndex].transform.position.x + Random.Range(-spawnRangeColliderSize.x / 2f, spawnRangeColliderSize.x / 2f);
                float posZ = enemySpawnerObjs[randSpawnerIndex].transform.position.z + Random.Range(-spawnRangeColliderSize.z / 2f, spawnRangeColliderSize.z / 2f);

                print(new Vector3(posX, 0, posZ));
                Instantiate(enemyObj, new Vector3(spawnRangeColliderCenter.x + posX, 0, spawnRangeColliderCenter.z + posZ), Quaternion.identity);
                nowSpawnCoolTime = 0;
            }
        }
    }
} 
