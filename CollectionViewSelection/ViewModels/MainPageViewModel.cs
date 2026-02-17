using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Test11.Models;

namespace Test11.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Project> _projects = [];

    [ObservableProperty]
    private Project? _selectedProject;

    [ObservableProperty]
    private Project? _project;

    [ObservableProperty]
    private bool _isProjectPickerExpanded;

    public MainPageViewModel()
    {
        LoadProjects();
    }

    private void LoadProjects()
    {
        Projects =
        [
            new Project { Id = 1, Name = "Project Alpha", Description = "First project" },
            new Project { Id = 2, Name = "Project Beta", Description = "Second project" },
            new Project { Id = 3, Name = "Project Gamma", Description = "Third project" },
            new Project { Id = 4, Name = "Project Delta", Description = "Fourth project" },
            new Project { Id = 5, Name = "Project Epsilon", Description = "Fifth project" },
        ];
    }

    [RelayCommand]
    private async Task NavigateToProject(Project? project)
    {
        if (project is null)
            return;

        await Shell.Current.DisplayAlert("Selected", $"You selected: {project.Name}", "OK");

        SelectedProject = null;
    }
}
