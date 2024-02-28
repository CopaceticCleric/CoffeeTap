// Author: Nick Nadolski
// Date: 02/21/24

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFillLine : MonoBehaviour
{
    // Method to update the Y position based on the new value of 'actual'
    public void UpdateYPosition(int actual, int actualMax, int actualMin)
    {
        float maxY = -36.73f;
        float minY = -38.35f;

        // Calculate the new y position
        float ratio = (float)(actual - actualMin) / (float)(actualMax - actualMin);
        float newYPosition = minY + ratio * (maxY - minY);

        // Clamp the newYPosition within the minY and maxY bounds
        newYPosition = Mathf.Clamp(newYPosition, minY, maxY);

        // Set the new Y position
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
