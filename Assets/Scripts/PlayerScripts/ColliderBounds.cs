using UnityEngine;
public class ColliderBounds : MonoBehaviour
{
    Collider2D m_Collider2D;
    Vector2 m_Center;
    Vector2 m_Size, m_Min, m_Max;

    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider2D = GetComponent<Collider2D>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider2D.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider2D.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider2D.bounds.min;
        m_Max = m_Collider2D.bounds.max;
        //Output this data into the console
        OutputData();
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Bounds : " + m_Collider2D.bounds);
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
         Debug.Log("extents : " + m_Collider2D.bounds.extents);
    }
}