using src.Interfaces;

namespace src.Invokers;

public class CommandHistory
{
    private readonly Stack<ICommand> _history = new();
    private readonly Stack<ICommand> _undoHistory = new();

    public void Execute(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void Undo()
    {
        if (_history.Any())
        {
            var history = _history.Pop();
            history.Undo();
            _undoHistory.Push(history);
        }
    }

    public void Redo()
    {
        if (_undoHistory.Any())
        {
            var history = _undoHistory.Pop();
            history.Execute();
            _history.Push(history);
        }
    }
}
