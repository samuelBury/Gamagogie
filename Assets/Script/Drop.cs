using UnityEngine;

public class Drop : MonoBehaviour
{
    // Références aux objets fileSpawn et filePlacement
    public Transform fileSpawn; // Point de départ
    public Transform filePlacement; // Point de destination (le bas)

    // Variables pour la simulation de la chute
    public float initialSpeed = 2f; // La vitesse initiale de chute (0 au début)
    public float gravity = 20.8f; // Simulation de la gravité, qui va accélérer l'objet
    private float currentSpeed; // Vitesse actuelle qui sera modifiée par la gravité

    // Booléen pour contrôler le mouvement
    private bool isFalling = false;

    void Start()
    {
        // Initialiser la vitesse à 0 au départ
        currentSpeed = initialSpeed;

        // Démarrer la chute
        StartFalling();
    }

    void Update()
    {
        if (isFalling)
        {
            // Simuler l'accélération de la chute due à la gravité
            currentSpeed += gravity * Time.deltaTime;

            // Déplacer l'objet vers le bas à la vitesse actuelle (qui augmente avec le temps)
            transform.position = Vector3.MoveTowards(transform.position, filePlacement.position, currentSpeed * Time.deltaTime);

            // Arrêter la chute si l'objet atteint filePlacement
            if (Vector3.Distance(transform.position, filePlacement.position) < 0.1f)
            {
                isFalling = false; // Arrête le mouvement une fois arrivé en bas
            }
        }
    }

    // Méthode pour démarrer la chute
    public void StartFalling()
    {
        // Positionner l'objet au niveau de fileSpawn (point de départ)
        transform.position = fileSpawn.position;

        // Commencer la chute
        isFalling = true;
    }
}
