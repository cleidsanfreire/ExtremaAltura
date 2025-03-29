using UnityEngine;

public class HeightConstruction : MonoBehaviour
{
    public float HeightCurrent()
    {
        bool heightFound = false;

        while (!heightFound)
        {
            if (Physics.CheckBox(transform.position, new Vector3(15f,1f,15f))) 
            {
                transform.position += Vector3.up;
            }
            else
            {
                heightFound = true;
            }
        }

        return transform.position.y;
    }
}
