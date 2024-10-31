using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    private Rigidbody2D _rigidbody2D;
    private float _defaultGravityScale;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _defaultGravityScale = _rigidbody2D.gravityScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.position = ScreenToWorldPoint(eventData);
        
        Debug.Log("OnPointerClick");
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = ScreenToWorldPoint(eventData);
        
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = ScreenToWorldPoint(eventData);
        
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = ScreenToWorldPoint(eventData);
        _rigidbody2D.gravityScale = _defaultGravityScale;
        
        Debug.Log("OnEndDrag");
    }
    
    private Vector3 ScreenToWorldPoint(PointerEventData eventData)
    {
        Vector3 screenPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        screenPoint.z = 0;
        return screenPoint;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = Vector2.zero;
    }
}