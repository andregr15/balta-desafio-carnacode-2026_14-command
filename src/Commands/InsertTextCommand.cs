

using src.Interfaces;
using src.Models;

namespace src.Commands;

public class InsertTextCommand(TextEditorV2 textEditor, string text)
    : ICommand
{
    private readonly TextEditorV2 _textEditor = textEditor;
    private readonly string _text = text;

    public void Execute()
    {
        _textEditor.InsertText(_text);
    }

    public void Undo()
    {
        _textEditor.DeleteText(_text.Length);
    }
}
