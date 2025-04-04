using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObj;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Selecionar Objeto
            if(selectedObj == null)
            {
                RaycastHit hit = CastRay();
                if(hit.collider != null)
                {
                    if(!hit.collider.CompareTag("DraggableObject"))
                    {
                        return;
                    }

                    selectedObj = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            //Soltar objeto
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObj.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObj.transform.position = new Vector3(worldPosition.x, 0f , worldPosition.z);

                selectedObj = null;
                Cursor.visible = true;
            }
        }
        //Objeto já selecionado
        if(selectedObj != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObj.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObj.transform.position = new Vector3(worldPosition.x, .25f , worldPosition.z);

            if(Input.GetMouseButton(1))
            {
                selectedObj.transform.rotation = Quaternion.Euler(new Vector3(selectedObj.transform.rotation.eulerAngles.x, selectedObj.transform.rotation.eulerAngles.y+90, selectedObj.transform.rotation.eulerAngles.z));
            }

            if(Input.GetMouseButton(3))
            {
                selectedObj.transform.position = new Vector3(worldPosition.x, worldPosition.y , worldPosition.z);
            }
        }
        
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }   
}
