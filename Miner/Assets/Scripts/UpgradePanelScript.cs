using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour {
    Animator an;
	void Start () {
        an = GetComponent<Animator>();
	}

    public void Open()
    {
        an.SetTrigger("enabled");
    }

    public void Close()
    {
        an.SetTrigger("enabled");
    }
}
