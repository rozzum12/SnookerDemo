using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//public class PocketTrigger : MonoBehaviour
//{
//    public float destroyDelay = 0.5f;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Ball"))
//        {
//            StartCoroutine(RemoveBallAfterDelay(other.gameObject));
//        }
//        else if (other.name == "WhiteBall")
//        {
//            Debug.Log("White ball pocketed!");
//        }
//    }

//    private System.Collections.IEnumerator RemoveBallAfterDelay(GameObject ball)
//    {
//        float timeLeft = destroyDelay;
//        while (timeLeft > 0f)
//        {
//            timeLeft -= Time.deltaTime;
//        }
//            Destroy(ball);
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
        float timeLeft = destroyDelay;

        while (timeLeft > 0f)
        {
            float scale = timeLeft / destroyDelay;
            ball.transform.localScale = Vector3.one * scale;
            Color endColor = Color.black;
            ball.GetComponent<MeshRenderer>().material.color = Color.Lerp(endColor, GetComponent<MeshRenderer>().material.color, scale);


            timeLeft -= Time.deltaTime;
            yield return null;
        }

        Destroy(ball);
    }
}



