using System;
using System.Collections.Generic;

namespace TestingTrabajo.Models
{
    interface ProfileRepository
    {
        List<Profile> GetAll();
        bool Save(Profile profile);
    }
}
