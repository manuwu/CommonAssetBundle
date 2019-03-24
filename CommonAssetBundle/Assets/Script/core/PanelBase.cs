using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour {
    public string skinPath;
    public GameObject skin;
    public PanelLayer layer;
    public object[] args;

    public virtual void Init(params object[] args)
    {
        this.args = args;
    }

    public virtual void OnShowing() { }
    public virtual void OnShowed() { }
    public virtual void Update() { }
    public virtual void OnCloseing() { }
    public virtual void OnClosed() { }

    protected virtual void Close()
    {
        string name = this.GetType().ToString();
        PanelManager.instance.ClosePanel(name);
    }

}
