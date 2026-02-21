using src.Interfaces;
using src.Models;

namespace src.Commands;

public class SetBoldCommand(TextEditorV2 textEditor, int start, int length) : ICommand
{
    private readonly TextEditorV2 _textEditor = textEditor;
    private readonly int _start = start;
    private readonly int _length = length;

    public void Execute()
    {
        _textEditor.SetBold(_start, _length);
    }

    public void Undo()
    {
        _textEditor.RemoveBold(_start, _length);
    }
}
