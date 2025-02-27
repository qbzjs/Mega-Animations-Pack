using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIcons : MonoBehaviour
{
    [SerializeField] Transform character;

    private void LateUpdate()
    {
        Vector3 newPos = character.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(90, character.eulerAngles.y + 270, 0);
    }
}
