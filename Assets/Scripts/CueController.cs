using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class CueController : MonoBehaviour
//{
//    public Transform ballTransform;     
//    public float rotationSpeed = 10f;   
//    public Camera mainCamera;           

//    public GameObject cueVisual;        
//    private bool isVisible = true;
//    private bool isFollowing = true;

//    void Update()
//    {
//        if (!isFollowing) return;

//        transform.position = ballTransform.position;

//        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

//        Plane plane = new Plane(Vector3.up, new Vector3(0, ballTransform.position.y, 0));

//        if (plane.Raycast(ray, out float enter))
//        {
//            Vector3 hitPoint = ray.GetPoint(enter);
//            Vector3 direction = hitPoint - ballTransform.position;
//            direction.y = 0f;

//            if (direction.sqrMagnitude > 0.001f)
//            {
//                Quaternion targetRotation = Quaternion.LookRotation(direction);
//                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * Quaternion.Euler(0, -90, 0), Time.deltaTime * rotationSpeed);
//            }
//        }
//    }

//    public void ShowCue()
//    {
//        isVisible = true;
//        isFollowing = true;
//        cueVisual.SetActive(true);
//    }

//    public void HideCue()
//    {
//        isVisible = false;
//        isFollowing = false;
//        cueVisual.SetActive(false);
//    }
//}


public class CueController : MonoBehaviour
{
    public Transform ballTransform;
    public float rotationSpeed = 10f;
    public Camera mainCamera;
    public GameObject cueVisual;

    private bool isActive = true;

    void Update()
    {
        if (!isActive) return;

        transform.position = ballTransform.position;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, new Vector3(0, ballTransform.position.y, 0));

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = hitPoint - ballTransform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                targetRotation *= Quaternion.Euler(0, -90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    public void ShowCue()
    {
        isActive = true;
        cueVisual.SetActive(true);
    }

    public void HideCue()
    {
        isActive = false;
        cueVisual.SetActive(false);
    }
}
