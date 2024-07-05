using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropdown;
    
    [SerializeField]
    private List<Target> navigationTargetObjecects = new List<Target>();
    
    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    private bool lineToggle = false;


    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>();
        line.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(lineToggle && targetPosition != Vector3.zero){
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
    }

    public void setCurrentNavigationTarget(int selectedValue){
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropdown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjecects.Find(x => x.Name == selectedText);
        if(currentTarget != null){
            Debug.Log("Selected Target: " + currentTarget.Name);
            targetPosition = currentTarget.PositionObject.transform.position;
            Debug.Log("Target Position"+targetPosition);
        }
    }

     public void ToggleVisibility(){
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }
}
