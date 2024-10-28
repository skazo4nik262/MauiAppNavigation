namespace MauiApp1;

public partial class StudentAddServicesView : ContentPage
{
    private Student student = new Student();
    private List<Group> groups;

    public List<Group> Groups { get => groups; set { groups = value; OnPropertyChanged(); } }
    public Student Student { get => student; set => student = value; }
    public Group SelectedGroup { get; set; }

    public StudentAddServicesView()
	{
		InitializeComponent();
        BindingContext = this;
	}

    protected override void OnAppearing()
    {
        GetGroups();
    }
    public async void GetGroups()
    {
        Groups = await DbNoEntity.Instance.GetListGroups();
    }
    private async void SaveClick(object sender, EventArgs e)
    {
        Student.GroupId = SelectedGroup.Id;
        Student.SetGroup();
        DbNoEntity.Instance.AddStudent(Student);
        int studentId = await DbNoEntity.Instance.AddStudent(Student);
        DbNoEntity.Instance.GroupAddStudent(SelectedGroup.Id, studentId);
    }
}