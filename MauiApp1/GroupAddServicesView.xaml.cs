namespace MauiApp1;

public partial class GroupAddServicesView : ContentPage
{
    private List<Student> students;

    public GroupAddServicesView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        GetStudentsAndGroups();
    }
    public async void GetStudentsAndGroups()
    {
        Students = await DbNoEntity.Instance.GetListStudent();
        Groups = await DbNoEntity.Instance.GetListGroups();
    }

    public List<Student> Students { get => students; set { students = value; OnPropertyChanged(); } }
    public List<Student> SelectedStudents { get; set; } = new List<Student>();
    public Group Group { get; set; } = new Group();
    public List<Group> Groups { get; set; } = new List<Group>();
    private void SaveClick(object sender, EventArgs e)
    {
        //var a = Groups.Where(s => s.Number == Group.Number);
        int b = Groups.Count(s => s.Number == Group.Number);
        if (b == 0)
        {
            //Group.Students.AddRange(SelectedStudents);
            //foreach (var item in SelectedStudents)
            //    item.GroupId = Group.Id;
            DbNoEntity.Instance.AddGroup(Group);
        }
        else
            DisplayAlert("Error", "Group already exists in DB", "OK");
    }
}