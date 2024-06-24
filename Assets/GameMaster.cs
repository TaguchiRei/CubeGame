using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static float _gameMode = 0;
    [SerializeField] GameObject _upperText;
    [SerializeField] GameObject _buttonText;
    Text _upText;
    Text _buttText;
    Camera _camera;
    public static float _mousePositionX;
    public static float _mousePositionY;
    public static float _haveKey =0;
    public static bool _link = false;
    public static bool _linkMode =false;
    public static bool key = true;
    private void Start()
    {
        _upperText = GameObject.Find("左上テキスト");
        _buttonText = GameObject.Find("ボタンテキスト");
        _upText = _upperText.GetComponent<Text>();
        _buttText = _buttonText.GetComponent<Text>();
        _upText.text = "制作中";
        _buttText.text = "プレイ";
        _camera = Camera.main;
    }
    private void Update()
    {
        var WorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        var x = Math.Floor(WorldPoint.x) + 0.5;
        var y = Math.Floor(WorldPoint.y) + 0.5;
        _mousePositionX = (float)x;
        _mousePositionY = (float)y;
        if (GameMaster._gameMode == 0)
        {
            ResetGame();
        }
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
    private void ResetGame()
    {
        _haveKey = 0;
    }
}
