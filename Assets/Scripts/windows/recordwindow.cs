using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///脚本：recordwindow.cs
///时间：2022/9/2 16:03
///功能：存档界面
///</summary>
public class recordwindow : windowRoot
{
    public PlayerControl playerController;
    public GameObject[] dataArr;
    public GameWindow gameWindow;

    [HideInInspector]
    public int datachooseNum = 0;

    protected override void Initwindow()
    {
        base.Initwindow();
        ShowData();
    }

    private void ShowData()
    {
        for (int i = 0; i < dataArr.Length; i++)
        {
            ResourceSvc.SaveData saveData = resourceSvc.GetSaveData(i);
            string state = saveData.state;
            string deathcount = "Death:" + saveData.deathcount.ToString();
            string time = "Time:" + saveData.time;
            dataArr[i].transform.GetChild(1).GetComponent<Text>().text = state;
            dataArr[i].transform.GetChild(2).GetComponent<Text>().text = deathcount;
            dataArr[i].transform.GetChild(3).GetComponent<Text>().text = time;
        }
    }

    private void Update()
    {
        ChangeChoose();
        EnterGame();
    }

    private void ChangeChoose()
    {
        RectTransform datachoose = transform.Find("datachoose").GetComponent<RectTransform>();
        float posx = datachoose.localPosition.x;
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            posx = posx >= 600f ? 0f : posx + 300f;
            datachooseNum = datachooseNum >= 2 ? 0 : datachooseNum + 1;
            datachoose.localPosition = new Vector2(posx, datachoose.localPosition.y);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            posx = posx <= 0f ? 600f : posx - 300f;
            datachooseNum = datachooseNum <= 0 ? 2 : datachooseNum - 1;
            datachoose.localPosition = new Vector2(posx, datachoose.localPosition.y);
        }
    }

    private void EnterGame()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerController.InitPlayer();
            SetWindowState(false);
            gameWindow.SetWindowState(true);
            
        }
    }
}
