using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("현재 최대 스폰 쿨타임")]
    private float maxSpawnCoolTime;

    [SerializeField]
    [Tooltip("현재 스폰 쿨타임")]
    private float nowSpawnCoolTime;

    [SerializeField]
    [Tooltip("시간당 소환될 적 오브젝트")]
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
