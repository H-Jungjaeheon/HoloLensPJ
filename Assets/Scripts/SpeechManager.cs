using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManager : MonoBehaviour
{
    public GameObject cube;

    public void OnOffCube()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStartSpeech()
    {
        cube.SetActive(false);
        GameManager.Instance.IsGameStart = true;
    }
}
