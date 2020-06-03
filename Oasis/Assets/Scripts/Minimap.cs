using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Transform FoW;
    public int y;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = FoW.position.y + 2;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
