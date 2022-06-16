using UnityEngine;

public class Corona : MonoBehaviour
{

    public float Vitesse = 5; // on choisit la vitesse de déplacement
    private int direction = 1; // nous sert a changer de direction
    private float retard = 5.0f;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > retard)
        {
            transform.position = transform.position + new Vector3(0, 0, Vitesse * direction * Time.deltaTime);
        }
    }
}
