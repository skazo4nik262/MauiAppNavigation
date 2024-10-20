using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class DbNoEntity
    {
        private static DbNoEntity instance;
        private List<Student> Students { get; set; }
        private List<User> Users { get; set; }
        private List<Group> Groups { get; set; }
        private Student Student { get; set; }
        private Group Group { get; set; }
        private User User { get; set; }

        private int lastStudentId = 1;
        private int lastUserId = 1;
        private int lastGroupId = 1;
        public DbNoEntity()
        {
            Students = new List<Student>();
            Students.Add(new Student { Id = lastStudentId, FIO = "ФИО", Birthday = "2024, 10, 19", IsBoy = true, Address = "Бородинская 16", GroupId = lastGroupId });
            Groups = new List<Group>();
            Groups.Add(new Group { Id = lastGroupId, Number = "1135", Students = new List<Student> { new Student { Id = lastStudentId, FIO = "НеФИО", Birthday = "2024, 10, 19", IsBoy = true, Address = "Бородинская 16" } } });
            Users = new List<User>();
            Users.Add(new User { Id = lastUserId, Login = "123", Password = "123" });
        }

        public static DbNoEntity Instance { get { return instance ??= new DbNoEntity(); } }


        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(100);
            return new List<User>(Users);
        }
        public async Task<List<Student>> GetListStudent()
        {
            await Task.Delay(100);
            foreach (var item in Students)
            {
                item.SetGroup();
            }
            return new List<Student>(Students);
        }
        public async Task<List<Group>> GetListGroups()
        {
            await Task.Delay(100);
            return new List<Group>(Groups);
        }
        public async Task<Student> GetStudentById(int id)
        {
            await Task.Delay(100);
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return null;
            Student getStudent = new Student()
            {
                Id = student.Id,
                FIO = student.FIO,
                Birthday = student.Birthday,
                Address = student.Address,
                IsBoy = student.IsBoy,
                GroupId = student.GroupId,
            };
            return getStudent;
        }
        public async Task<Group> GetGroupById(int id)
        {
            await Task.Delay(100);
            var group = Groups.FirstOrDefault(x => x.Id == id);
            if (group == null)
                return null;
            Group getGroup = new Group()
            {
                Id = group.Id,
                Number = group.Number,
                Students = group.Students
            };
            return getGroup;
        }
        public async Task/*<int>*/ AddStudent(Student student)
        {
            await Task.Delay(100);
            Student newStudent = new Student()
            {
                Id = ++lastStudentId,
                FIO = student.FIO,
                Address = student.Address,
                IsBoy = student.IsBoy,
                Birthday = student.Birthday,
                GroupId = student.GroupId,
            };
            Students.Add(newStudent);
            int a = lastStudentId - 1;
            //return a;
        }
        public async Task AddUser(User user)
        {
            await Task.Delay(100);
            User newUser = new User()
            {
                Id = ++lastUserId,
                Login = user.Login,
                Password = user.Password,
            };
            Users.Add(newUser);
        }
        public async Task AddGroup(Group group)
        {
            await Task.Delay(100);
            Group newGroup = new Group()
            {
                Id = ++lastGroupId,
                Number = group.Number,
                Students = group.Students
            };
            Groups.Add(newGroup);
        }
        public async Task EditStudent(Student student)
        {
            await Task.Delay(100);
            var thisStudent = Students.FirstOrDefault(s => s.Id == student.Id);
            thisStudent.Id = student.Id;
            thisStudent.FIO = student.FIO;
            thisStudent.Birthday = student.Birthday;
            thisStudent.Address = student.Address;
            thisStudent.IsBoy = student.IsBoy;
            thisStudent.GroupId = student.GroupId;
        }
        public async Task EditGroup(Group group)
        {
            await Task.Delay(100);
            var thisGroup = Groups.FirstOrDefault(s => s.Id == group.Id);
            thisGroup.Id = group.Id;
            thisGroup.Number = group.Number;
            thisGroup.Students = group.Students;
        }
        public async Task DeleteStudentByID(Student student)
        {
            await Task.Delay(100);
            var thisStudent = Students.FirstOrDefault(s => s.Id == student.Id);
            if (thisStudent.Id == student.Id)
                Students.Remove(student);
        }
        public async Task DeleteGroupByID(Group group)
        {
            await Task.Delay(100);
            var thisGroup = Groups.FirstOrDefault(s => s.Id == group.Id);
            if (thisGroup.Id == group.Id)
                Groups.Remove(group);
        }
        public async Task<bool> CheckUserIsNotInDB(string userLogin)
        {
            Task.Delay(100);
            if (Users.Where(s => s.Login == userLogin).Count() != 0)
                return false;
            else return true;
        }

        public async Task GroupAddStudent(int groupId, int studentId)
        {
            await Task.Delay(100);
            var studentLocal = Students.FirstOrDefault(s => s.Id == studentId);
            var group = Groups.FirstOrDefault(s=>s.Id == groupId);
            group.Students.Add(studentLocal);
        }
    }
}
