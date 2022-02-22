using AMS.Model;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AMS.Repositories.Generic
{
    public interface IAgreementRepository
    {
        AgreementListViewModel GetAgreements(string draw,string start,string length,string sortColumn,string sortColumnDirection,string searchValue);
        NewAgreeViewModel AddEdit(int? id);
        int DeleteAgreement(int Id);
        int SaveAgreement(NewAgreeViewModel unit);
    }
}