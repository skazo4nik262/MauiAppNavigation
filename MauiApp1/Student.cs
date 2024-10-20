using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class Student
    {
        public int Id { get; set; }//
        public string FIO { get; set; }//
        public string Birthday { get; set; }//
        public bool IsBoy { get; set; }//

        [NotMapped]
        public string Gender { get => IsBoy ? "Мужской" : "Женский"; }
        public string Address { get; set; }//
        public int GroupId { get; set; }//
        public Group Group { get; private set; }

        public override string ToString()
        {
            return $"{FIO}: День рождения: {Birthday},\n Пол: {Gender},\n Адрес проживания: {Address}";
        }
        public async void SetGroup()
        {
            Group = await DbNoEntity.Instance.GetGroupById(GroupId);
        }
    }
}
