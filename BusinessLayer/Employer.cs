using System.ComponentModel.DataAnnotations.Schema;

namespace Apply_Jobs.BusinessLayer
{
    //Holds employee information
    public class Employer
    {
        //Primary key
        public int Id { get; set; }

        //Name of the employee
        public string Name { get; set; }

        //Employee contact number.
        public string ContactNumber { get; set; }

        //Employee website
        public string WebSite { get; set; }

        //Employee registration number.
        [NotMapped]
        public string RegistrationNumber
        {

            get
            {
                return "E" + Id;
            }
        }
    }
}
