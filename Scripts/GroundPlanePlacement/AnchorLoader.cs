using UnityEngine; 
using Vuforia; 

public class AnchorLoader : MonoBehaviour
{
    // Öffentliches Feld für das Objekt, das platziert werden soll
    public GameObject objectToPlace;

    // Methode, die beim Start des Spiels oder beim Aktivieren des GameObjects aufgerufen wird
    void Start()
    {
        LoadAnchorData(); // Lädt die Ankerdaten
    }

    // Methode zum Laden der gespeicherten Ankerdaten
    void LoadAnchorData()
    {
        // Überprüft, ob Ankerdaten im PlayerPrefs gespeichert sind
        if (PlayerPrefs.HasKey("AnchorX"))
        {
            // Liest die gespeicherten Positionsdaten aus
            Vector3 position = new Vector3(
                PlayerPrefs.GetFloat("AnchorX"),
                PlayerPrefs.GetFloat("AnchorY"),
                PlayerPrefs.GetFloat("AnchorZ")
            );

            // Liest die gespeicherten Rotationsdaten aus
            Quaternion rotation = new Quaternion(
                PlayerPrefs.GetFloat("AnchorRotX"),
                PlayerPrefs.GetFloat("AnchorRotY"),
                PlayerPrefs.GetFloat("AnchorRotZ"),
                PlayerPrefs.GetFloat("AnchorRotW")
            );

            // Erstellt ein neues AnchorBehaviour-Objekt mit den gespeicherten Positionen und Rotationen
            AnchorBehaviour anchor = VuforiaBehaviour.Instance.ObserverFactory.CreateAnchorBehaviour("SavedAnchor", position, rotation);

            // Platziert das Objekt an dem Anker
            InstantiateObjectAtAnchor(anchor);
        }
    }

    // Methode zur Instanziierung des Objekts an dem Anker
    void InstantiateObjectAtAnchor(AnchorBehaviour anchor)
    {
        // Überprüft, ob sowohl das Objekt als auch der Anker nicht null sind
        if (objectToPlace != null && anchor != null)
        {
            // Instanziiert das Objekt an der Position und Rotation des Ankers
            GameObject placedObject = Instantiate(objectToPlace, anchor.transform.position, anchor.transform.rotation);

            // Setzt das instanziierte Objekt als Child des Ankers
            placedObject.transform.parent = anchor.transform;
        }
    }
}
