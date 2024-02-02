using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovering = false;
    public GameObject cat;
    private rotate_fast catRotationScript;

    private void Start()
    {
        catRotationScript = cat.GetComponent<rotate_fast>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        catRotationScript.rotationSpeed = 500f; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        catRotationScript.rotationSpeed = 0f; 
    }

    private void Update()
    {

        if (!isHovering)
        {
            catRotationScript.rotationSpeed = 0f;
        }
    }
}

