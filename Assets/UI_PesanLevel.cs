using TMPro;
using UnityEngine;

public class UI_PesanLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _tempatPesan = null;
    
    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
