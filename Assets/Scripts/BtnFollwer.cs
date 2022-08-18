using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnFollwer : MonoBehaviour
{
    [SerializeField]
    private GameObject dest;
    [SerializeField]
    private GameObject lookAtDest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, dest.transform.position, Time.deltaTime);
        //transform.LookAt(lookAtDest.transform.position);
    }

    public void ButtonPress()
    {
        print("´­¸²");
        
    }
}
