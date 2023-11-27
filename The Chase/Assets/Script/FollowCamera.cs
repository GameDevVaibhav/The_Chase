using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 offset=new Vector3(0f,0f,-10f);
    private Vector3 velocity=Vector3.zero;

    private string selectedColor;

    private Camera mainCamera;

    [SerializeField]
    private Transform target;

    private void Start()
    {
        selectedColor = PlayerPrefs.GetString("selectedColor");
        Debug.Log("color"+selectedColor);


        mainCamera =Camera.main;
        Color newColor;
        ColorUtility.TryParseHtmlString(selectedColor, out newColor);
        mainCamera.backgroundColor = newColor;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0f);

    }
}
