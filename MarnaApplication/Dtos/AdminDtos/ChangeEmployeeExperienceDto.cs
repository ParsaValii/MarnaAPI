using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarnaApplication.Dtos.AdminDtos
{
    public class ChangeEmployeeExperienceDto
    {
        public Guid Id { get; set; }
        public int years { get; set; }
    }
}