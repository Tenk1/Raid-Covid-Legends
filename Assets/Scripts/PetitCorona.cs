using UnityEngine;

public class PetitCorona : MonoBehaviour
{
    public float Vitesse = 5;
    public Vector2 Offset = new Vector2(-5, 5);
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > Offset.y)
            direction = -1;
        else if (transform.position.x < Offset.x)
            direction = 1;


        transform.position = transform.position + new Vector3(Vitesse * direction * Time.deltaTime, 0, 0);	   
    }
}
