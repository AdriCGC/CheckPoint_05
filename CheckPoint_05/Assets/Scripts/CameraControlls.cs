using Unity.VisualScripting;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    [Header("Parametros de camera")]

    [SerializeField] private float cameraSpeed;
    [SerializeField] private float leftborder, rightborder, upborder, downborder; 

    [Header("Referencia ao Player")]

    [SerializeField] private Transform player;


    void Update()
    {
        Vector3 CameraPosition = new Vector3(player.position.x, player.position.y, transform.position.z );

        CameraPosition.x = Mathf.Clamp(CameraPosition.x, leftborder, rightborder);
        CameraPosition.y = Mathf.Clamp(CameraPosition.y, downborder, upborder);


        transform.position = Vector3.Lerp(transform.position, CameraPosition, cameraSpeed * Time.deltaTime );
    }
}
