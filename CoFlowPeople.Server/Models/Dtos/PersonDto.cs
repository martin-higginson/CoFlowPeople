﻿namespace CoFlowPeople.Server.Models.Dtos
{
    public class PersonDto
    {
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required DateTime DateOfBirth { get; set; }
	}
}
