using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;

namespace LetMeRate.Application.Services
{
    public interface IAuthorisationService
    {
        dynamic CreateAuthorisationToken(AuthorisationCredentialsCommand command);
    }
}
