using AspDotNetCoreSecurity.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreSecurity.Repositories
{
    public class ConferenceRepo
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        private readonly IDataProtector _dataProtector;

        public ConferenceRepo(IDataProtectionProvider protectionProvider, PurposeStringConstants purposeStringConstants)
        {
            _dataProtector = protectionProvider.CreateProtector(purposeStringConstants.ConferenceIdQueryString);
            conferences.Add(new ConferenceModel { Id = 1, Name = "Developer Week", EncryptedId=_dataProtector.Protect("1"), Location = "Nuremberg", Start = new DateTime(2018, 6, 25) });
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", EncryptedId= _dataProtector.Protect("2"),  Location = "San Francisco", Start = new DateTime(2018, 10, 18) });
           
        }
        public IEnumerable<ConferenceModel> GetAll()
        {
            return conferences;
        }

        public ConferenceModel GetById(int id)
        {
            return conferences.First(c => c.Id == id);
        }

        public void Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            model.EncryptedId = _dataProtector.Protect(model.Id.ToString());
            conferences.Add(model);
        }
    }
}
