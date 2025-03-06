using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public enum PuckType
{
    NORMAL,
    WEIGHT,
    BIG
}

public class GamePuckBuilder : MonoBehaviour
{
    public int normalPucksSelected = 1;
    public int weightPucksSelected = 1;
    public int bigPucksSelected = 1;
    public int maxPucks = 7;
    [Header("Buttons")]
    public Button addNormalPuck;
    public Button removeNormalPuck;
    public Button addWeightPuck;
    public Button removeWeightPuck;
    public Button addBigPuck;
    public Button removeBigPuck;

    public Button confirmButton;
    [Header("TMP_Text")]
    public TMP_Text normalPucksText;
    public TMP_Text weightPucksText;
    public TMP_Text bigPucksText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addNormalPuck.onClick.AddListener(AddNormalPuck);
        removeNormalPuck.onClick.AddListener(RemoveNormalPuck);

        addWeightPuck.onClick.AddListener(AddWeightPuck);
        removeWeightPuck.onClick.AddListener(RemoveWeightPuck);

        addBigPuck.onClick.AddListener(AddBigPuck);
        removeBigPuck.onClick.AddListener(RemoveBigPuck);

        confirmButton.onClick.AddListener(Confirm);


        UpdateConfirmButton();
    }

    private void AddNormalPuck()
    {
        AddRemovePuckType(PuckType.NORMAL, true);
    }
    private void RemoveNormalPuck()
    {
        AddRemovePuckType(PuckType.NORMAL, false);
    }
    private void AddWeightPuck()
    {
        AddRemovePuckType(PuckType.WEIGHT, true);
    }
    private void RemoveWeightPuck()
    {
        AddRemovePuckType(PuckType.WEIGHT, false);
    }
    private void AddBigPuck()
    {
        AddRemovePuckType(PuckType.BIG, true);
    }
    private void RemoveBigPuck()
    {
        AddRemovePuckType(PuckType.BIG, false);
    }
    public void Confirm()
    {
        Debug.Log("ho confermato e ho "+ maxPucks+ " Pucks ^^");
    }

    private void AddRemovePuckType(PuckType _puckType, bool _AddRemove)
    {
        switch (_puckType)
        {
            case PuckType.NORMAL:
                AddRemovePucks(_AddRemove, ref normalPucksSelected, normalPucksText);
                break;
            case PuckType.WEIGHT:
                AddRemovePucks(_AddRemove, ref weightPucksSelected, weightPucksText);
                break;
            case PuckType.BIG:
                AddRemovePucks(_AddRemove, ref bigPucksSelected, bigPucksText);
                break;
        }
    }

    public void AddRemovePucks(bool _AddRemove, ref int _pucksSelected, TMP_Text _updateUI)
    {
        if (_AddRemove)
        {
            if (normalPucksSelected + weightPucksSelected + bigPucksSelected < maxPucks)
            {
                _pucksSelected++;
            }
            else { }
        }
        else
        {
            if (_pucksSelected > 1)
            {
                _pucksSelected--;
            }
        }
        _updateUI.text = _pucksSelected.ToString();
        UpdateConfirmButton();
    }

    public void UpdateConfirmButton()
    {
        if (normalPucksSelected + weightPucksSelected + bigPucksSelected < maxPucks)
            confirmButton.interactable = false;
        else
            confirmButton.interactable = true;
    }
}
