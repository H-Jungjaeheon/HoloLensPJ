using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singleton<TitleManager>
{
    [SerializeField]
    private GameObject TitleObj;

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
    IEnumerator GameGuideTextAnimStart()
    {
        WaitForSeconds waitForObjTruing = new WaitForSeconds(2.5f);
        WaitForSeconds waitForObjFalsing = new WaitForSeconds(1);
        while (GameManager.Instance.IsGameStart == false)
        {
            GameStartGuideObj.SetActive(true);
            yield return waitForObjTruing;
            GameStartGuideObj.SetActive(false);
            yield return waitForObjFalsing;
        }
    }
}
