using UnityEngine; // Importiert das Unity-Framework
using Vuforia; // Importiert die Vuforia-Bibliothek für Augmented Reality

public class ObjectPlacer : MonoBehaviour
{
    // Öffentliches Feld für das Objekt, das platziert werden soll
    public GameObject objectToPlace;

    // Methode, die einmal pro Frame aufgerufen wird
    void Update()
    {
        // Überprüft, ob die linke Maustaste gedrückt wurde
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPosition = Input.mousePosition; // Holt die Position des Mauszeigers
            PlaceObject(screenPosition); // Platziert das Objekt an der Mausposition
        }

        // Überprüft, ob es Touch-Eingaben gibt
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Holt den ersten Touch-Eingang
            if (touch.phase == TouchPhase.Began) // Überprüft, ob der Touch gerade begonnen hat
            {
                Vector2 screenPosition = touch.position; // Holt die Position des Touch-Eingangs
                PlaceObject(screenPosition); // Platziert das Objekt an der Touch-Position
            }
        }
    }

    // Methode zum Platzieren des Objekts an der angegebenen Bildschirmposition
    void PlaceObject(Vector2 screenPosition)
    {
        // Erstellt einen Anker basierend auf einem Hit-Test an der angegebenen Bildschirmposition
        AnchorBehaviour anchor = CreateAnchorFromHitTest(screenPosition, 1.0f);
        if (anchor != null) // Überprüft, ob der Anker erfolgreich erstellt wurde
        {
            InstantiateObjectAtAnchor(anchor); // Instanziiert das Objekt am Anker
            SaveAnchorData(anchor); // Speichert die Ankerdaten
        }
    }

    // Methode zur Erstellung eines Ankers basierend auf einem Hit-Test
    AnchorBehaviour CreateAnchorFromHitTest(Vector2 imageSpacePos, float defaultHeight)
    {
        AnchorBehaviour anchor = null; // Initialisiert den Anker als null
        HitTestResult hitTestResult; // Definiert eine Variable für das Hit-Test-Ergebnis
        // Führt einen Hit-Test durch und überprüft, ob ein Treffer gefunden wurde
        if (VuforiaBehaviour.Instance.World.HitTest(imageSpacePos, defaultHeight, out hitTestResult))
        {
            // Erstellt ein neues AnchorBehaviour-Objekt basierend auf dem Hit-Test-Ergebnis
            anchor = VuforiaBehaviour.Instance.ObserverFactory.CreateAnchorBehaviour("HitTestAnchor", hitTestResult);
        }

        return anchor; // Gibt den erstellten Anker zurück
    }

    // Methode zur Instanziierung des Objekts am Anker
    void InstantiateObjectAtAnchor(AnchorBehaviour anchor)
    {
        // Überprüft, ob sowohl das Objekt als auch der Anker nicht null sind
        if (objectToPlace != null && anchor != null)
        {
            // Instanziiert das Objekt an der Position und Rotation des Ankers
            GameObject placedObject = Instantiate(objectToPlace, anchor.transform.position, anchor.transform.rotation);
            // Setzt das instanziierte Objekt als Kind des Ankers
            placedObject.transform.parent = anchor.transform;
        }
    }

    // Methode zum Speichern der Ankerdaten in den PlayerPrefs
    void SaveAnchorData(AnchorBehaviour anchor)
    {
        Vector3 position = anchor.transform.position; // Holt die Position des Ankers
        Quaternion rotation = anchor.transform.rotation; // Holt die Rotation des Ankers
        
        // Speichert die Positionsdaten in den PlayerPrefs
        PlayerPrefs.SetFloat("AnchorX", position.x);
        Play
    }
}
