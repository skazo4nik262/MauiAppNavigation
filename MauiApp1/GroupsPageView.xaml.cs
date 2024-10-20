namespace MauiApp1;

public partial class GroupsPageView : ContentPage
{
    private List<Student> students;
    private List<Group> groups;

    public Group SelectedGroup { get; set; }
    public List<Group> Groups { get => groups; set { groups = value;  OnPropertyChanged(); } }
    public List<Student> Students { get => students; set { students = value; OnPropertyChanged();} }

    public GroupsPageView()
	{
		InitializeComponent();
        Dkghf();
        BindingContext = this;

	}
    protected override void OnAppearing()
    {
        Dkghf();
    }
    private async void Dkghf()
    {
        Groups = await DbNoEntity.Instance.GetListGroups();
        Students = await DbNoEntity.Instance.GetListStudent();
    }

    private async void EditGroupClick(object sender, EventArgs e)
    {
        ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()
        {
            {"Group", SelectedGroup }
        };
        await Shell.Current.GoToAsync("//GroupAddServices", shellQuery);
    }

    private async void DeleteGroupClick(object sender, EventArgs e)
    {
        await DbNoEntity.Instance.DeleteGroupByID(SelectedGroup);
        Dkghf();
    }

    private async void AddGroupClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//GroupAddServices");
    }
}