using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManager : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameStartSpeech();
        }
    }

    public void GameStartSpeech()
    {
        if (GameManager.Instance.nowGameState != GameState.Main) return;
        TitleManager.Instance.TitleObj.SetActive(false);
        GameManager.Instance.ChangeGameState(GameState.GunChoose);
    }


}
