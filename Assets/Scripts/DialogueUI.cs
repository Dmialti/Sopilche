using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    private void Start()
    {
        GetComponent<TypewriterEffect>().Run("Здарова песюни)))\nНу чо посмакуєм\nLazyegg", textLabel);
    }
}
