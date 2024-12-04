using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditorInternal;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    private static CanvasManager _instance;
    public static CanvasManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
    }

    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    }

    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }
}
