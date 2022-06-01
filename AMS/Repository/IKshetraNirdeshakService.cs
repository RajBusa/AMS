using AMS.Models;

namespace AMS.Repository
{
    public interface IKshetraNirdeshakService
    {
        Task<IEnumerable<KshetraNirdeshak>> GetAllKshetraNirdeshak();

        Task<IEnumerable<KshetraNirdeshak>> GetKshetraNirdeshak(int id);

        Task<int> DeleteKshetraNirdeshak(int id);

        Task<int> UpdateKshetraNirdeshak(KshetraNirdeshak kshetraNirdeshak);

        Task<int> InsertKshetraNirdeshak(KshetraNirdeshak kshetraNirdeshak);
    }
}
