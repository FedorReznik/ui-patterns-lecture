namespace MVVM.Engine.AppState;

public interface IMainVm : IViewModel
{
    IViewModel? CurrentVm { get; set; }
}