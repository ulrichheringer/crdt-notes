using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CrdtNotes.Sync;

namespace CrdtNotes.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly NoteReplica _ana = new("Ana");
    private readonly NoteReplica _bruno = new("Bruno");
    [ObservableProperty] private string _anaDraft = "Revisar capítulo 3";
    [ObservableProperty] private string _brunoDraft = "Adicionar exemplos ao capítulo 3";
    [ObservableProperty] private string _resolved = "Edite nos dois lados e sincronize.";
    [ObservableProperty] private string _syncStatus = "Duas réplicas independentes, prontas para editar.";

    [RelayCommand]
    private void SyncConcurrentEdits()
    {
        _ana.Edit(AnaDraft); _bruno.Edit(BrunoDraft);
        _ana.Merge(_bruno); _bruno.Merge(_ana);
        Resolved = _ana.Value.Text;
        SyncStatus = $"Réplicas convergiram para a versão {_ana.Value.Clock}, escolhida pelo par (relógio lógico, nome da réplica). Vencedor: {_ana.Value.Replica}.";
    }

    [RelayCommand]
    private void Reset()
    {
        _ana.Reset(); _bruno.Reset();
        AnaDraft = "Revisar capítulo 3"; BrunoDraft = "Adicionar exemplos ao capítulo 3";
        Resolved = "Edite nos dois lados e sincronize."; SyncStatus = "Duas réplicas independentes, prontas para editar.";
    }
}
