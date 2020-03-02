namespace Apply_Jobs.BusinessLayer
{
    //Holds application infomation.
    public class Application
    {
        //Primary key of application
        public int Id { get; set; }

        //Advertisement foriegn key
        public int AdvertisementId { get; set; }

        //CANDIDATE ID foriegn key.
        public int CandidateId { get; set; }

        //Advertisement reference
        public Advertisement Advertisement { get; set; }

        //Candidate reference 
        public Candidate Candidate { get; set; }





    }
}
