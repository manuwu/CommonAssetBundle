using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelManager : MonoBehaviour
{


    public static PanelManager instance;
    private GameObject canvas;
    public Dictionary<string, PanelBase> dict;
    private Dictionary<PanelLayer, Transform> layerDict;

    public void Awake()
    {
        instance = this;
        InitLayer();
        dict = new Dictionary<string, PanelBase>();

    }

    private void InitLayer()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas == null)
            Debug.LogError("my");
        layerDict = new Dictionary<PanelLayer, Transform>();
        foreach (  PanelLayer pl in Enum.GetValues(typeof(PanelLayer)))
        {
            string name = pl.ToString();
            Transform transform = canvas.transform.Find(name);
            layerDict.Add(pl, transform);
        }
    }

    public void OpenPanel<T>(string skinPath, params object[] args) where T : PanelBase
    {
        string name = typeof(T).ToString();
        if (dict.ContainsKey(name))
        return;
        PanelBase panel = canvas.AddComponent<T>();
        panel.Init(args);
        dict.Add(name, panel);
        skinPath = (skinPath != "" ? skinPath : panel.skinPath);
        GameObject skin = Resources.Load<GameObject>(skinPath);
        if (skin == null)
            Debug.LogError("");
        panel.skin = (GameObject)Instantiate(skin);
        Transform skinTrans = panel.skin.transform;
        PanelLayer layer = panel.layer;
        Transform parent = layerDict[layer];
        skinTrans.SetParent(parent, false);
        panel.OnShowing();
        //Anima
        panel.OnShowed();

    }

    public void ClosePanel(string name)
    {

        PanelBase panel = (PanelBase)dict[name];
        if (panel == null)
            return;

        panel.OnCloseing();
        dict.Remove(name);
        panel.OnClosed();
        GameObject.Destroy(panel.skin);
        Component.Destroy(panel);
    }
}

