using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static float _gameMode = 0;
    [SerializeField] GameObject _upperText;
    [SerializeField] GameObject _buttonText;
    Text _upText;
    Text _buttText;
    private void Start()
    {
        _upperText = GameObject.Find("����e�L�X�g");
        _buttonText = GameObject.Find("�{�^���e�L�X�g");
        _upText = _upperText.GetComponent<Text>();
        _buttText = _buttonText.GetComponent<Text>();
        _upText.text = "���쒆";
        _buttText.text = "�v���C";
    }
    public void GameMode()
    {
        if (_gameMode == 0)
        {
            
            _gameMode = 1;
            _upText.text = "�v���C��";
            _buttText.text = "�ҏW";
        }
        else
        {
            _gameMode = 0;
            _upText.text = "���쒆";
            _buttText.text = "�v���C";
        }
    }
}
