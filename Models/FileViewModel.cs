using System;

namespace Lab2.Models
{
    public class FileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FileViewModel(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
