using System.ComponentModel.DataAnnotations.Schema;

namespace Apply_Jobs.BusinessLayer
{
    //Holds candidate information.
    public class Candidate
    {
        //Primary key.
        public int Id { get; set; }

        //Candidate name.
        public string Name { get; set; }

        //Candidate registration number 
        [NotMapped]
        public string RegsitrationNumber
        {

            get { return "C00" + Id + "-" + Name; }
        }

        //Contact phone number
        public string ContactNumber { get; set; }



    }
}
