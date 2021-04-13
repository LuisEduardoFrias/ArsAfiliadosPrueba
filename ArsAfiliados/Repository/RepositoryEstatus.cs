
namespace ArsAfiliados.Repository
{
    public class RepositoryEstatus
    {
        #region Singletom

        public static RepositoryEstatus Instantice { get; set; }

        public static RepositoryEstatus GetInstance()
        {
            if (Instantice == null)
                Instantice = new RepositoryEstatus();

            return Instantice;
        }

        #endregion
    }
}
