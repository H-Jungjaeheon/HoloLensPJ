using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpeechCommand
{ 
    GameStart,
    GameRestart,
    ChangeGun,
    RocketLauncher
}


public class SpeechManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gunHitBoxObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeSpeech(0);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            ChangeSpeech(1);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            ChangeSpeech(2);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            ChangeSpeech(3);
        }
    }

    public void ChangeSpeech(int nowSpeechCommandIndex)
    {
        var gameManagerInstance = GameManager.Instance;
        switch (nowSpeechCommandIndex)
        {
            case (int)SpeechCommand.GameStart:
                if (gameManagerInstance.nowGameState != GameState.Main) return;
                TitleManager.Instance.TitleObj.SetActive(false);
                gameManagerInstance.ChangeGameState(GameState.Playing);
                break;
            case (int)SpeechCommand.GameRestart:
                if (gameManagerInstance.nowGameState != GameState.GameClear || gameManagerInstance.nowGameState != GameState.GameOver) return;
                break;
            case (int)SpeechCommand.ChangeGun:
                if (gameManagerInstance.nowGameState != GameState.Playing) return;
                if (gameManagerInstance.isGunChangeAble)
                {
                    if (gameManagerInstance.nowGunState == GunState.MachineGun)
                    {
                        gameManagerInstance.GunChangeCoolTimeCoroutine();
                        gameManagerInstance.ChangeGun(GunState.ShotGun);
                        gunHitBoxObj.GetComponent<Gun>().ChangeHitBoxSize(false);
                    }
                    else
                    {
                        gameManagerInstance.GunChangeCoolTimeCoroutine();
                        gameManagerInstance.ChangeGun(GunState.MachineGun);
                        gunHitBoxObj.GetComponent<Gun>().ChangeHitBoxSize(true);
                    }
                }
                break;
            case (int)SpeechCommand.RocketLauncher:
                if (gameManagerInstance.nowGameState != GameState.Playing) return;
               gameManagerInstance.ChangeGun(GunState.RocketLauncher); //�ڷ�ƾ ���Ϸ�ó �߻� �ִϸ��̼�
                break;
        }
    }


}
