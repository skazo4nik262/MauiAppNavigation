namespace MauiApp1;

public partial class StudentsPageView : ContentPage
{

    public List<Student> Students { get; set; } = new List<Student>();
    public Student SelectedStudent {  get; set; } = new Student();
    //public List<Group> Groups { get; set; } = new List<Group>();
    //public Group Group { get; set; } = new Group();

    public StudentsPageView()
	{
		InitializeComponent();
        Dkghf();
        BindingContext = this;
	}
    private async void Dkghf()
    {
        Students = await DbNoEntity.Instance.GetListStudent();
    }
    protected override void OnAppearing()
    {
        Dkghf();
    }
    private async void EditStudentClick(object sender, EventArgs e)
    {
        ShellNavigationQueryParameters shellQuery = new ShellNavigationQueryParameters()
        {
            {"Student/", SelectedStudent }
        };
        await Shell.Current.GoToAsync("//StudentAddServices", shellQuery);
    }

    private async void DeleteStudentClick(object sender, EventArgs e)
    {
        await DbNoEntity.Instance.DeleteStudentByID(SelectedStudent);
        Dkghf();
    }

    private async void AddStudentClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//StudentAddServices");
    }
}