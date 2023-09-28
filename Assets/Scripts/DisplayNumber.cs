using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNumber : MonoBehaviour
{
    public Text _displayText;
    public Text _displayTotalText;
    public Text _displayScoreText;

    public GameManager _countDrag;
    public GameObject _notifyPanel;
    // Start is called before the first frame update
    void Start()
    {
        _displayText.text = "0/16";
        _notifyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _displayText.text = _countDrag._count + "/16";
    }

    public void DisplayTotal()
    {
        _notifyPanel.SetActive(true);
        _displayTotalText.text = "Total: " + _countDrag._count + "/16";
        _displayScoreText.text = "Score: " + Score();
    }

    private int Score()
    {
        return (_countDrag._count / 16) * 100;
    }
}
