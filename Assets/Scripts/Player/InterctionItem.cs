using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterctionItem : MonoBehaviour
{
    [SerializeField] private GameObject _player;  

    private Camera _camera;

    private float _lengthRay = 1.5f;

    private bool _inHand;

    private GameObject _itemRise;

    public static Action Rise = delegate { };
    public static Action<GameObject> Throw = delegate { };

    private void Start()
    {
        TriggerController.DestroyItem += OnDestroyItem;
        _camera = GetComponent<Camera>();
        _inHand = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_inHand)
            {
                ToRaiseItem();
            }
            else 
            {
                ThrowItem();
            }
        }
    }

    void ToRaiseItem() 
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        RaycastHit hit;

        Physics.Raycast(ray, out hit, _lengthRay);

        if (hit.collider != null && hit.collider.gameObject.tag == "Item")
        {
            _itemRise = hit.collider.gameObject;

            Rise();

            hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
            hit.transform.parent = _player.transform;

            _inHand = true;
        }
    }

    void ThrowItem() 
    {
        if (_itemRise != null)
        {
            Throw(_itemRise);
        }
    }

    void OnDestroyItem() 
    {
        _inHand = false;
    }

    private void OnDestroy()
    {
        TriggerController.DestroyItem -= OnDestroyItem;
    }
}
