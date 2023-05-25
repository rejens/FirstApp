namespace FirstApp.Models;

public class StudentVm
{
    public long Id { get; set; }
    public String Name { get; set; }
    public String Address { get; set; }
    

    // public long Id;
    // public string Name;
    // public string Address;

    public StudentVm(long id, string name, string address)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
    }
}