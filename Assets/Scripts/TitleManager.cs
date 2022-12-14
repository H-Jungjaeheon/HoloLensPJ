using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singleton<TitleManager>
{
    public GameObject TitleObj;

    [SerializeField]
    private GameObject GameStartGuideObj;

    // Start is called before the first frame update
    void Start()
    {
        GameGuideTextAnim(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameGuideTextAnim()
    {
        StartCoroutine(GameGuideTextAnimStart());
    }

    public void GameStart()
    {
        StartCoroutine(GameStartSetting());
    }

    public void GameOver()
    {
        print("???ӿ???");
    }

    IEnumerator GameGuideTextAnimStart()
    {
        WaitForSeconds waitForObjTruing = new WaitForSeconds(2.5f);
        WaitForSeconds waitForObjFalsing = new WaitForSeconds(1);
        while (GameManager.Instance.nowGameState == GameState.Main)
        {
            GameStartGuideObj.SetActive(true);
            yield return waitForObjTruing;
            GameStartGuideObj.SetActive(false);
            yield return waitForObjFalsing;
        }
    }

    IEnumerator GameStartSetting()
    {
        GameManager.Instance.Hp = 3;
        TitleObj.SetActive(false);
        yield return null;
    }

}
