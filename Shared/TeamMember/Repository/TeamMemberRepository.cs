using System;
using System.Collections.Generic;

namespace BlazorApp.Shared.TeamMember.Repository
{
    public class TeamMemberRepository
    {
        public IEnumerable<Model.TeamMember> GetTeamMembers()
        {
            return new List<Model.TeamMember> {
                new Model.TeamMember
                {
                    FirstName = "Henry",
                    LastName = "S",
                    EmailAddress = Guid.NewGuid().ToString()
                },
                new Model.TeamMember
                {
                    FirstName = "Bill",
                    LastName = "L",
                    EmailAddress = Guid.NewGuid().ToString()
                },
                new Model.TeamMember
                {
                    FirstName = "Jenna",
                    LastName = "S",
                    EmailAddress = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
