namespace webtemplate.Models;
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Person(string id, string name) {
            this.Id = id;
           this.Name = name;
        }
    }
    //tag helper giống tính năng của label for
    // dùng để hiển thị nhãn không giống thuộc tính đó có thể cấu hình ở model

