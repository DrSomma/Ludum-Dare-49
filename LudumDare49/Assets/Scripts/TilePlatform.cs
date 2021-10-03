using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlatform : MonoBehaviour
{
    [SerializeField]
    private int NumberOfMaxVisits = 1;

    public int CurNumberOfVisitsLeft;

    void Start()
    {
        CurNumberOfVisitsLeft = NumberOfMaxVisits;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player On Platform", this);
            CurNumberOfVisitsLeft--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Left Platform", this);
        }
    }
}
