

using src.Interfaces;
using src.Models;

namespace src.Commands;

public class DeleteTextCommand(TextEditorV2 textEditor, int length) : ICommand
{
    private readonly TextEditorV2 _textEditor = textEditor;
    private readonly int _length = length;
    private string _deletedText = string.Empty;

    public void Execute()
    {
        _deletedText = _textEditor.GetContent()
            .Substring(_textEditor.GetCursorPosition() - _length, _length);
        _textEditor.DeleteText(_length);
    }

    public void Undo()
    {
        _textEditor.InsertText(_deletedText);
    }
}
