using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            //맞으면 색 바뀌는 코드 넣기
            if (value <= 0)
            {
                Destroy(gameObject);
            }
            hp = value;
        }
    }

    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        StartSetting();
    }

    void StartSetting()
    {
        playerObj = GameManager.Instance.PlayerObj;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Hp -= 1;
            Destroy(gameObject);
        }
    }
}
