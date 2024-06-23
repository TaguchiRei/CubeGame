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
        _upperText = GameObject.Find("左上テキスト");
        _buttonText = GameObject.Find("ボタンテキスト");
        _upText = _upperText.GetComponent<Text>();
        _buttText = _buttonText.GetComponent<Text>();
        _upText.text = "制作中";
        _buttText.text = "プレイ";
    }
    public void GameMode()
    {
        if (_gameMode == 0)
        {
            
            _gameMode = 1;
            _upText.text = "プレイ中";
            _buttText.text = "編集";
        }
        else
        {
            _gameMode = 0;
            _upText.text = "制作中";
            _buttText.text = "プレイ";
        }
    }
}
