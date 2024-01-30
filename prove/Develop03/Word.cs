using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string wordText)
    {
        _text = wordText;
        _isHidden = false; // Words are visible by default
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}