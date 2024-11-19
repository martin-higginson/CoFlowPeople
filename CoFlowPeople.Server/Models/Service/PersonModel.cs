namespace CoFlowPeople.Server.Models.Service
{
    public class PersonModel
    {
		public int Id { get; set; }

		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }

		public DateTime DateCreated { get; set; }

		public int Age
		{
			get
			{
				return DateTime.Now.Year - DateOfBirth.Year;
			}
		}
	}
}
