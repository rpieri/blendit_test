using BlendIt.Test.Shared.Commands;

namespace BlendIt.Test.Shared.ViewModels
{
    public abstract class ViewModelCommand<TCommand> : ViewModel where TCommand : Command
    {
        public abstract TCommand Mapping();
    }
}
