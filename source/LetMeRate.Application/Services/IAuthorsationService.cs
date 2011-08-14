using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetMeRate.Application.Commands;
using LetMeRate.Application.Query;

namespace LetMeRate.Application.Services
{
    public interface IAuthorisationService
    {
        dynamic CreateAuthorisationToken(AuthorisationCredentialsCommand command);
        dynamic GetAuthorsation(GetAuthorisationQuery query);
    }
}
