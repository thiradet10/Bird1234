using UnityEngine;

public class Pipescript : MonoBehaviour
{
    
    public float deadZone = -15f;

    void Update()
    {
        
        if (GameManager.instance != null)
        {
            transform.position = transform.position + (Vector3.left * GameManager.instance.pipeSpeed * Time.deltaTime);
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}