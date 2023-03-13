using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///脚本：windowRoot.cs
///时间：2022/9/2 16:50
///功能：窗口基类
///</summary>
public class windowRoot : MonoBehaviour
{
    protected ResourceSvc resourceSvc;

    public void SetWindowState(bool ifActive)
    {
        if(gameObject.activeSelf != ifActive)
        {
            gameObject.SetActive(ifActive);
        }
        if(ifActive)
        {
            Initwindow();
        }
        else
        {
            Clearwindow();
        }
    }

    protected virtual void Initwindow()
    {
        resourceSvc = ResourceSvc.Instance;
    }

    protected virtual void Clearwindow()
    {
        resourceSvc = null;
    }
}
