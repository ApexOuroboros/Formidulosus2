using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    
    public List<GameObject> ShipPartsArray = new List<GameObject>();

    private List<GameObject> shipPartsArrayPriv = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShipPartsArray.Count == 0 || shipPartsArrayPriv.Count == 5)
        {
            SceneManager.LoadScene("end");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        for(int i = 0; i < ShipPartsArray.Count; i++)
        {
            if (other.gameObject.tag.Equals("Part"))
            {
                
                shipPartsArrayPriv.Add(other.gameObject);
                ShipPartsArray.Remove(other.gameObject);

                other.gameObject.SetActive(false);
            }
        }
        
    }
}
