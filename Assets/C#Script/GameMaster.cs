using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static float _gameMode = 0;
    GameObject _upperText;
    GameObject _buttonText;
    Text _upText;
    Text _buttonText1;
    Camera _camera;
    public static float _mousePositionX;
    public static float _mousePositionY;
    public static float _haveKey =0;
    public static bool _link = false;
    public static bool _keyLinkMode =false;
    public static bool _boxLinkMode = false;
    public static bool key = true;
    private void Start()
    {
        _upperText = GameObject.Find("左上テキスト");
        _buttonText = GameObject.Find("ボタンテキスト");
        _upText = _upperText.GetComponent<Text>();
        _buttonText1 = _buttonText.GetComponent<Text>();
        _upText.text = "Making...";
        _buttonText1.text = "Play!";
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
            _upText.text = "PlayMode";
            _buttonText1.text = "Make";
        }
        else
        {
            _gameMode = 0;
            _upText.text = "Making...";
            _buttonText1.text = "Play!";
        }
    }
    private void ResetGame()
    {
        _haveKey = 0;
    }
}
