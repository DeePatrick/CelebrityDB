namespace CelebrityDB.Models
{
    public class Celebrity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public string StageName { get; set; }
        public string  Race { get; set; }
        public string AgeCategory { get; set; }
        public string BodyShape { get; set; }
        public string  HeightCategory { get; set; }
        public string Hobbies { get; set; }
        public string Quotes { get; set; }
        public string Gender { get; set; }
        public byte[] EmployeePicture { get; set; }
        public byte[] EmployeeFullPicture { get; set; }

    }

}