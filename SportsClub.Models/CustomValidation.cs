using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub.Models
{
    // eigen validatie attribute voor leeftijd
    internal class MinimumAgeAttribute(int minimumAge) : ValidationAttribute
    {
        // IsValid is een methode die al in de base class zit
        // we vervangen deze dus hier met onze eigen implementatie
        public override bool IsValid(object? value)
        {
            // datum correct als datum type instellen
            DateTime birthDate = Convert.ToDateTime(value);
            // controleren of geboortedatum minstens x aantal jaren geleden was
            if (birthDate <= DateTime.Today.AddYears(-minimumAge)) return true;
            // niet OK --> false
            return false;
        }
    }
}
