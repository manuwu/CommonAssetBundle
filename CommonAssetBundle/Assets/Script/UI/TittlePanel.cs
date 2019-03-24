using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TittlePanel : PanelBase {

    private Button startBtn;
    private Button infoBtn;
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "titlePanel";
        layer = PanelLayer.Panel;

    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        startBtn = skinTrans.Find("StartBtn").GetComponent<Button>();
        infoBtn = skinTrans.Find("infoBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartClick);
        infoBtn.onClick.AddListener(OnInfoClick);

    }

    private void OnStartClick()
    {

        Close();
    }

    private void OnInfoClick()
    {
        PanelManager.instance.OpenPanel<TittlePanel>("");
    }
}
