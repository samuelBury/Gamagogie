using UnityEngine;

public class Drop : MonoBehaviour
{
    // R�f�rences aux objets fileSpawn et filePlacement
    public Transform fileSpawn; // Point de d�part
    public Transform filePlacement; // Point de destination (le bas)

    // Variables pour la simulation de la chute
    public float initialSpeed = 2f; // La vitesse initiale de chute (0 au d�but)
    public float gravity = 20.8f; // Simulation de la gravit�, qui va acc�l�rer l'objet
    private float currentSpeed; // Vitesse actuelle qui sera modifi�e par la gravit�

    // Bool�en pour contr�ler le mouvement
    private bool isFalling = false;

    void Start()
    {
        // Initialiser la vitesse � 0 au d�part
        currentSpeed = initialSpeed;

        // D�marrer la chute
        StartFalling();
    }

    void Update()
    {
        if (isFalling)
        {
            // Simuler l'acc�l�ration de la chute due � la gravit�
            currentSpeed += gravity * Time.deltaTime;

            // D�placer l'objet vers le bas � la vitesse actuelle (qui augmente avec le temps)
            transform.position = Vector3.MoveTowards(transform.position, filePlacement.position, currentSpeed * Time.deltaTime);

            // Arr�ter la chute si l'objet atteint filePlacement
            if (Vector3.Distance(transform.position, filePlacement.position) < 0.1f)
            {
                isFalling = false; // Arr�te le mouvement une fois arriv� en bas
            }
        }
    }

    // M�thode pour d�marrer la chute
    public void StartFalling()
    {
        // Positionner l'objet au niveau de fileSpawn (point de d�part)
        transform.position = fileSpawn.position;

        // Commencer la chute
        isFalling = true;
    }
}
