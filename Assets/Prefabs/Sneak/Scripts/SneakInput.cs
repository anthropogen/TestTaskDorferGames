using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakInput : MonoBehaviour
{
    private Vector3 _tapPosition;
    private bool _isMobile;
    private Camera _mainCamera;
    private bool _isTouched=false;
    private void Awake()
    {
        _mainCamera = Camera.main;
        _isMobile = Application.isMobilePlatform;
    }
    private void Update()
    {
        if (!_isMobile)
        {
            if (Input.GetMouseButton(0))
            {
                ConvertPosition(Input.mousePosition);
                _isTouched = true;
            }
            else 
                _isTouched = false;
        }
        else
        {
            if (Input.touchCount > 0)
            {
                ConvertPosition(Input.GetTouch(0).position);
                _isTouched = true;
            }
            else
                _isTouched = false;
            
        }
    }
   private void ConvertPosition(Vector3 tapPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(tapPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _tapPosition = hit.point;
        }
    }
   public Vector3 GetDiretion(Vector3 headPosition)
    {
        if (_isTouched)
        {
            Vector3 direction = new Vector3(_tapPosition.x - headPosition.x, 0, 1);
            return direction;
        }
        return  Vector3.forward;
    }
}
