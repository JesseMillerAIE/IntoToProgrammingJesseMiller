using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Killzone killzone;

    private void Start()
    {
        killzone = FindObjectOfType<Killzone>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Color playercolour = other.gameObject.GetComponent<Renderer>().material.color;
            Debug.Log("Checkpoint Reached");
            killzone.UpdateCheckpointPosition(this.transform.position, playercolour);  
        }
    }
}
