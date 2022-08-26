using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();    
    }

    private void Spawn()
    {
        if (GameManager.Instance.IsGameStart)
        {
            nowSpawnCoolTime += Time.deltaTime;
            if (nowSpawnCoolTime >= maxSpawnCoolTime)
            {
                nowSpawnCoolTime = 0;
                Instantiate(enemyObj, transform.position, Quaternion.identity);
            }
        }
    }
} 
