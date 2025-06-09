using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ColliderOnTrigger : MonoBehaviour
//{
//    private bool isInTrigger = false;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("WhiteBall"))
//        {
//            Destroy(other.gameObject);
//        }
//    }
//}

public class PocketTrigger : MonoBehaviour
{
    public float destroyDelay = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(RemoveBallAfterDelay(other.gameObject));
        }
        else if (other.name == "WhiteBall")
        {
            Debug.Log("White ball pocketed!");
        }
    }

    private System.Collections.IEnumerator RemoveBallAfterDelay(GameObject ball)
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(ball);
    }
}
