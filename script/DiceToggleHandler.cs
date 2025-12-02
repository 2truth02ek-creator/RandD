using UnityEngine;
using UnityEngine.UI;

public class DiceToggleHandler : MonoBehaviour
{
    public void OnToggleChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            Debug.Log($"{toggle.name} º±≈√µ ");
        }
    }
}
