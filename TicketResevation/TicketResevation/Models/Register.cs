using TicketResevation.Data;

namespace TicketResevation.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string NID { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void registerUser(Register register)
        {
            ApplicationDbContext con = new ApplicationDbContext();

            var res = con.Registers.ToList();
            foreach (var item in res)
            {
                if(item.MobileNumber == register.MobileNumber) 
                {
                    throw new Exception("User Already Exists");
                }
            }
            con.Registers.Add(register);
            con.SaveChanges();
        }
    }
}
