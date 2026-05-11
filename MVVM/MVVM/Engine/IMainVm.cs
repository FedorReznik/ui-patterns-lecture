namespace MVVM.Engine;

public interface IMainVm : IViewModel
{
    IViewModel? CurrentVm { get; set; }
}