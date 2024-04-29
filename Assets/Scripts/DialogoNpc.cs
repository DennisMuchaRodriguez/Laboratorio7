using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoNpc : MonoBehaviour
{
    public Transform startPoint; 
    public Transform endPoint; 
    public float moveSpeed = 2f; 
    public float stopDuration = 2f; 

    private bool movingToEnd = true; 
    private bool isStopped = false;
    public TextMeshProUGUI interactionText;
    private void Update()
    {
     
        if (!isStopped)
        {
            if (movingToEnd)
            {
               
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
                {
                    movingToEnd = false;
                    StartCoroutine(StopAndMove());
                }
            }
            else
            {
                
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);

              
                if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
                {
                    movingToEnd = true;
                    StartCoroutine(StopAndMove());
                }
            }
        }
    }

    
    private IEnumerator StopAndMove()
    {
        isStopped = true; 
        yield return new WaitForSeconds(stopDuration); 

       
        isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(false); 
        }
    }
}
