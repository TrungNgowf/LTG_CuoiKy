using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Follow player
    [SerializeField] private GameObject player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Follow player
        transform.position = new Vector3(player.transform.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.transform.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
