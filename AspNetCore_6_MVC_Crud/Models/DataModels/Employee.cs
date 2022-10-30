namespace AspNetCore_6_MVC_Crud.Models.DataModels
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
