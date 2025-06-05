using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BallShooter : MonoBehaviour
//{
//    public Rigidbody ballRigidbody;
//    public float hitForce = 10f;
//    public CueController cueController;

//    public float minVelocityToStop = 0.05f;
//    private bool canHit = true;

//    private Vector2 _startMousePosition;

//    void Update()
//    {
//        if (ballRigidbody.velocity.magnitude < minVelocityToStop)
//        {
//            if (!canHit) cueController.ShowCue();
//            canHit = true;
//        }
//        else
//        {
//            if (canHit) cueController.HideCue();
//            canHit = false;
//        }

//        if (Input.GetMouseButtonDown(0) && canHit)
//        {
//            _startMousePosition = Input.mousePosition;
//        }

//        if (Input.GetMouseButtonUp(0) && canHit)
//        {
//            Vector2 endMousePosition = Input.mousePosition;
//            Vector2 mouseDirection = (endMousePosition - _startMousePosition).normalized;

//            Vector3 direction = new Vector3(mouseDirection.x, 0, mouseDirection.y);
//            ballRigidbody.AddForce(direction * hitForce, ForceMode.Impulse);

//            canHit = false;
//            cueController.HideCue();
//        }
//    }
//}





public class BallShooter : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public float hitForce = 10f;
    public CueController cueController;

    public float minVelocityToStop = 0.05f;
    private bool canHit = true;

    private Vector2 _startMousePosition;
    void Update()
    {
        if (ballRigidbody.velocity.magnitude < minVelocityToStop)
        {
            if (ballRigidbody.velocity != Vector3.zero)
            {
                ballRigidbody.velocity = Vector3.zero;
                ballRigidbody.angularVelocity = Vector3.zero;
            }

            if (!canHit) cueController.ShowCue();
            canHit = true;
        }
        else
        {
            if (canHit) cueController.HideCue();
            canHit = false;
        }

        if (Input.GetMouseButtonDown(0) && canHit)
        {
            _startMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && canHit)
        {
            Vector2 endMousePosition = Input.mousePosition;
            Vector2 mouseDirection = (endMousePosition - _startMousePosition).normalized;

            Vector3 direction = new Vector3(mouseDirection.x, 0, mouseDirection.y);
            ballRigidbody.AddForce(direction * hitForce, ForceMode.Impulse);

            canHit = false;
            cueController.HideCue();
        }
    }
}
