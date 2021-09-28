using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private bool _near = false;
    private string _nameItem;

    const string _clone = "(Clone)";

    public static Action DestroyItem = delegate { };
    public static Action<String> Count = delegate { };

    private void Start()
    {
        InterctionItem.Throw += OnThrow;
    }

    private void OnTriggerEnter(Collider other)
    {
        _near = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _near = false;
    }

    void OnThrow(GameObject item) 
    {
        _nameItem = item.name;
        _nameItem = _nameItem.Replace(_clone,"");

        if (this.tag == _nameItem && _near==true) 
        {
            Count(_nameItem);
            Destroy(item);
            DestroyItem();
        }
    }

    private void OnDestroy()
    {
        InterctionItem.Throw -= OnThrow;
    }
}
